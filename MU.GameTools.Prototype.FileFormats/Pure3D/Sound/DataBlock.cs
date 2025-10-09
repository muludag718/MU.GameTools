using System;
using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats.Pure3D.Sound
{
	public class DataBlock
	{
		public byte[] Unknown1 { get; set; }

		public string Type { get; set; }

		public byte[] Unknown2 { get; set; }

		public string Name { get; set; }

		public uint Length { get; set; }

		public byte[][] Value { get; set; }

		public DataBlock()
		{
		}

		public DataBlock(Stream input, Endian endian)
		{
			Deserialize(input, endian);
		}

		public void Serialize(Stream output, Endian endian)
		{
			output.WriteBytes(Unknown1);
			output.WriteValueU32((uint)(Type.Length - 1), endian);
			output.WriteString(Type);
			output.WriteBytes(Unknown2);
			output.WriteValueU32((uint)(Name.Length - 1), endian);
			output.WriteString(Name);
			switch (Type)
			{
			case "String\0":
				output.WriteValueU32((uint)(Value[0].Length - 1), endian);
				output.WriteBytes(Value[0]);
				break;
			case "String List\0":
			{
				output.WriteValueU32(Length, endian);
				for (int j = 0; j < Length; j++)
				{
					output.WriteValueU32((uint)(Value[j].Length - 1), endian);
					output.WriteBytes(Value[j]);
				}
				break;
			}
			case "EnvelopeData\0":
			{
				output.WriteValueU32(Length, endian);
				for (int i = 0; i < Length; i++)
				{
					output.WriteBytes(Value[i]);
				}
				break;
			}
			default:
				output.WriteBytes(Value[0]);
				break;
			}
		}

		public void Deserialize(Stream input, Endian endian)
		{
			Unknown1 = input.ReadBytes(9);
			uint num = input.ReadValueU32(endian);
			Type = input.ReadString((int)(num + 1));
			Unknown2 = input.ReadBytes(9);
			num = input.ReadValueU32(endian);
			Name = input.ReadString((int)(num + 1));
			switch (Type)
			{
			case "Float32\0":
				Value = new byte[1][];
				Value[0] = input.ReadBytes(4);
				break;
			case "Vector\0":
				Value = new byte[1][];
				Value[0] = input.ReadBytes(12);
				break;
			case "Bool\0":
				Value = new byte[1][];
				Value[0] = input.ReadBytes(1);
				break;
			case "String\0":
				Value = new byte[1][];
				num = input.ReadValueU32(endian);
				Value[0] = input.ReadBytes((int)(num + 1));
				break;
			case "String List\0":
			{
				Length = input.ReadValueU32(endian);
				Value = new byte[Length][];
				for (int j = 0; j < Length; j++)
				{
					num = input.ReadValueU32(endian);
					Value[j] = input.ReadBytes((int)(num + 1));
				}
				break;
			}
			case "EnvelopeData\0":
			{
				Length = input.ReadValueU32(endian);
				Value = new byte[Length][];
				for (int i = 0; i < Length; i++)
				{
					Value[i] = input.ReadBytes(8);
				}
				break;
			}
			default:
				throw new FormatException("Unknown patch type");
			}
		}
	}
}
