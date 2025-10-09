using System;
using System.Collections.Generic;
using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.Fight.Prototype1
{
	public abstract class P1Track : BaseTrack
	{
		public uint Unknown1 { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			output.WriteValueU32(Unknown1, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			Unknown1 = input.ReadValueU32(endianess);
		}

		public static void SerializeBaseTrack(Stream output, Endian endianess, BaseTrack track)
		{
			Stream stream = new MemoryStream();
			track.Serialize(stream, endianess);
			output.WriteValueU64(track.TypeHash, endianess);
			output.WriteValueU32((uint)stream.Length, endianess);
			stream.Seek(0L, SeekOrigin.Begin);
			output.WriteFromStream(stream, stream.Length);
			track.SerializeProperties(PrototypeGame.P1, output, endianess);
			output.WriteValueU64(0uL);
		}

		public static void SerializeBaseTracks(Stream output, Endian endianess, List<BaseTrack> tracks)
		{
			foreach (BaseTrack track in tracks)
			{
				SerializeBaseTrack(output, endianess, track);
			}
		}

		public static BaseTrack DeserializeBaseTrack(Stream input, Endian endianess, ulong hash)
		{
			BaseTrack obj = Factory<BaseTrack, KnownTrackAttribute>.Build(PrototypeGame.P1, hash) ?? throw new NotImplementedException("Unknown track");
			uint num = input.ReadValueU32(endianess);
			long position = input.Position;
			obj.Deserialize(input, endianess);
			if (input.Position != position + num)
			{
				throw new FormatException("Invalid track length");
			}
			obj.DeserializeProperties(PrototypeGame.P1, input, endianess);
			input.ReadValueU64();
			return obj;
		}

		public static List<BaseTrack> DeserializeBaseTracks(Stream input, Endian endianess)
		{
			List<BaseTrack> list = new List<BaseTrack>();
			while (true)
			{
				ulong num = input.ReadValueU64(endianess);
				if (num == 0L)
				{
					break;
				}
				list.Add(DeserializeBaseTrack(input, endianess, num));
			}
			input.Position -= 8L;
			return list;
		}
	}
}
