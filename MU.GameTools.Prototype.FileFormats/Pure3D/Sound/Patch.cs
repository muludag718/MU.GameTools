using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats.Pure3D.Sound
{
	public class Patch : AudioType
	{
		public byte[] Unknown1 { get; set; }

		public string Type { get; set; }

		public uint AmountOfBlocks { get; set; }

		public DataBlock[] DataBlocks { get; set; }

		public Patch()
		{
		}

		public Patch(Stream input, Endian endian)
			: base(input, endian)
		{
		}

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteBytes(Unknown1);
			output.WriteValueU32((uint)(Type.Length - 1), endian);
			output.WriteString(Type);
			output.WriteByte(0);
			output.WriteValueU32(AmountOfBlocks, endian);
			for (int i = 0; i < AmountOfBlocks; i++)
			{
				DataBlocks[i].Serialize(output, endian);
			}
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Unknown1 = input.ReadBytes(9);
			uint num = input.ReadValueU32(endian);
			Type = input.ReadString((int)(num + 1));
			input.ReadByte();
			AmountOfBlocks = input.ReadValueU32(endian);
			DataBlocks = new DataBlock[AmountOfBlocks];
			for (int i = 0; i < AmountOfBlocks; i++)
			{
				DataBlocks[i] = new DataBlock(input, endian);
			}
		}
	}
}
