using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MU.GameTools.IO;
using MU.GameTools.Prototype.FileFormats.Cement;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats
{
	public class CementFile
	{
		public Endian Endian;

		public byte MajorVersion;

		public byte MinorVersion;

		public uint EntryCount;

		public readonly List<Entry> Entries = new List<Entry>();

		public readonly Dictionary<uint, Entry> EntriesDict = new Dictionary<uint, Entry>();

		public readonly List<Metadata> Metadatas = new List<Metadata>();

		public CementFile()
		{
		}

		public CementFile(Stream input)
		{
			Deserialize(input);
		}

		public Metadata GetMetadata(uint hash)
		{
			return Metadatas.SingleOrDefault((Metadata candidate) => candidate.Name.HashFileName() == hash);
		}

		public int EstimateHeaderSize()
		{
			return ((0 + 24 + 8 + 28 + EstimateEntryTableSize()).Align(2048) + EstimateMetadataTableSize()).Align(2048);
		}

		public int EstimateEntryTableSize()
		{
			return Entries.Sum((Entry e) => Entry.ByteSize);
		}

		public int EstimateMetadataTableSize()
		{
			return 8 + Metadatas.Sum((Metadata e) => e.ByteSize);
		}

		public void Serialize(Stream output)
		{
			output.WriteString("ATG CORE CEMENT LIBRARY", 24, Encoding.ASCII);
			output.Seek(8L, SeekOrigin.Current);
			output.WriteValueU8(MajorVersion);
			output.WriteValueU8(MinorVersion);
			output.WriteValueB8((Endian != Endian.Little) ? true : false);
			output.WriteValueU8(1);
			int num = 60;
			int num2 = EstimateEntryTableSize();
			output.WriteValueS32(60, Endian);
			output.WriteValueS32(num2, Endian);
			num += num2;
			num = num.Align(2048);
			int value = EstimateMetadataTableSize();
			output.WriteValueS32(num, Endian);
			output.WriteValueS32(value, Endian);
			output.WriteValueU32(0u, Endian);
			output.WriteValueS32(Entries.Count, Endian);
			Entries.Sort((Entry a, Entry b) => a.Hash.CompareTo(b.Hash));
			foreach (Entry entry in Entries)
			{
				entry.Serialize(output, Endian);
			}
			output.Seek(output.Position.Align(2048L), SeekOrigin.Begin);
			output.WriteValueU32(2048u, Endian.Little);
			output.WriteValueU32(0u, Endian.Little);
			foreach (Metadata metadata in Metadatas)
			{
				metadata.Serialize(output, Endian);
			}
			output.MoveToAlign(2048);
			for (int num3 = 0; num3 < Entries.Count; num3++)
			{
				int num4 = (int)output.Position;
				output.Position = 60 + num3 * Entry.ByteSize + 4;
				output.WriteValueS32(num4, Endian);
				output.Position = num4;
				output.WriteBytes(Entries[num3].Data);
				output.MoveToAlign(2048);
			}
		}

		public void Deserialize(Stream input)
		{
			if (input.ReadString(24, trailingNull: true, Encoding.ASCII) != "ATG CORE CEMENT LIBRARY")
			{
				throw new FormatException("Not a Cement file");
			}
			input.ReadBytes(8);
			MajorVersion = input.ReadValueU8();
			MinorVersion = input.ReadValueU8();
			Endian = (input.ReadValueB8() ? Endian.Big : Endian.Little);
			input.ReadValueU8();
			uint num = input.ReadValueU32(Endian);
			uint size = input.ReadValueU32(Endian);
			uint num2 = input.ReadValueU32(Endian);
			uint size2 = input.ReadValueU32(Endian);
			input.ReadValueU32();
			EntryCount = input.ReadValueU32(Endian);
			input.Seek(num, SeekOrigin.Begin);
			using (MemoryStream memoryStream = input.ReadToMemoryStream((int)size))
			{
				Entries.Clear();
				for (int i = 0; i < EntryCount; i++)
				{
					Entry entry = new Entry();
					entry.Deserialize(memoryStream, Endian);
					Entries.Add(entry);
					EntriesDict.Add(entry.Hash, entry);
				}
				if (memoryStream.Position != memoryStream.Length)
				{
					throw new FormatException();
				}
			}
			input.Seek(num2, SeekOrigin.Begin);
			using (MemoryStream memoryStream2 = input.ReadToMemoryStream((int)size2))
			{
				memoryStream2.ReadValueU32(Endian.Little);
				memoryStream2.ReadValueU32(Endian.Little);
				Metadatas.Clear();
				for (int j = 0; j < EntryCount; j++)
				{
					Metadata metadata = new Metadata();
					metadata.Deserialize(memoryStream2, Endian);
					Metadatas.Add(metadata);
				}
			}
			foreach (Entry entry2 in Entries)
			{
				input.Seek(entry2.Offset, SeekOrigin.Begin);
				entry2.Data = input.ReadBytes((int)entry2.Size);
			}
		}

		public void Pack(string path)
		{
			string[] files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
			for (int i = 0; i < files.Length; i++)
			{
				files[i] = files[i].Substring(path.Length + 1, files[i].Length - path.Length - 1);
			}
			EntryCount = (uint)files.Length;
			for (int j = 0; j < EntryCount; j++)
			{
				Entry entry = new Entry
				{
					Hash = Utils.RCFStringHash(files[j])
				};
				using (FileStream fileStream = File.OpenRead(Path.Combine(path, files[j])))
				{
					using MemoryStream memoryStream = new MemoryStream();
					fileStream.CopyTo(memoryStream);
					entry.Data = memoryStream.ToArray();
					entry.Size = (uint)entry.Data.Length;
				}
				Entries.Add(entry);
				Metadata item = new Metadata
				{
					Date = DateTime.Now.GetUnixEpoch(),
					Name = files[j]
				};
				Metadatas.Add(item);
			}
		}

		public void Unpack(string path)
		{
			for (int i = 0; i < EntryCount; i++)
			{
				uint key = Utils.RCFStringHash(Metadatas[i].Name.Trim(default(char)));
				Entry entry = EntriesDict[key];
				string path2 = Metadatas[i].Name.Trim(default(char));
				string directoryName = Path.GetDirectoryName(path2);
				using FileStream stream = File.Create(Path.Combine(Directory.CreateDirectory(Path.Combine(path, directoryName)).FullName, Path.GetFileName(path2)));
				stream.WriteBytes(entry.Data);
			}
		}
	}
}
