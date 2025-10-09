using System;
using System.IO;
using System.Text;
using MU.GameTools.IO;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.Fight
{
	public class FightFile
	{
		public const uint Signature = 4282659664u;

		public const uint FigDataSignature = 536872706u;

		public uint Flags { get; set; }

		public uint Padding { get; set; }

		public FightChunk Chunk { get; set; }

		public void Deserialize(PrototypeGame game, Stream input, Endian endianess)
		{
			long position = input.Position;
			uint num = input.ReadValueU32(endianess);
			if (num != 4282659664u && num.Swap() != 4282659664u)
			{
				throw new FormatException("Not a Pure3D file");
			}
			if (input.ReadValueU32(endianess) != 12)
			{
				throw new FormatException("Invalid header size");
			}
			uint num2 = input.ReadValueU32(endianess);
			if (position + num2 > input.Length)
			{
				throw new FormatException();
			}
			if (input.ReadValueU32() != 536872706)
			{
				throw new FormatException("Not a fig data p3d");
			}
			input.ReadBytes(8);
			DeserializeFig(game, input, endianess);
		}

		public void DeserializeFig(PrototypeGame game, Stream input, Endian endianess)
		{
			uint num = input.ReadValueU32(endianess);
			long position = input.Position;
			if (input.ReadString(4, Encoding.ASCII) != "fig0")
			{
				throw new FormatException("Not a fight node");
			}
			Flags = input.ReadValueU32(endianess);
			Padding = input.ReadValueU32(endianess);
			if (input.ReadValueU64() != 7021078959221846271L)
			{
				throw new FormatException("Fight file doest not contain a chunk");
			}
			Chunk = new FightChunk(game, input, endianess);
			if (input.Position != num + position)
			{
				throw new FormatException("Invalid chunk length");
			}
		}

		public void Serialize(PrototypeGame game, Stream output, Endian endianess)
		{
			Stream stream = new MemoryStream();
			SerializeFig(game, stream, endianess);
			output.WriteValueU32(4282659664u, endianess);
			output.WriteValueU32(12u, endianess);
			output.WriteValueU32((uint)(stream.Length + 24), endianess);
			output.WriteValueU32(536872706u, endianess);
			output.WriteValueU32((uint)(stream.Length + 12), endianess);
			output.WriteValueU32((uint)(stream.Length + 12), endianess);
			stream.Seek(0L, SeekOrigin.Begin);
			output.WriteFromStream(stream, stream.Length);
		}

		public void SerializeFig(PrototypeGame game, Stream output, Endian endianess)
		{
			Stream stream = new MemoryStream();
			stream.WriteString("fig0");
			stream.WriteValueU32(Flags, endianess);
			stream.WriteValueU32(Padding, endianess);
			Chunk.Serialize(game, stream, endianess);
			output.WriteValueU32((uint)stream.Length, endianess);
			stream.Seek(0L, SeekOrigin.Begin);
			output.WriteFromStream(stream, stream.Length);
		}
	}
}
