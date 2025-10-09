using System;
using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownType(1183753u)]
	public class TranslationReference : BaseNode
	{
		public uint Pad { get; set; }

		public string Reference { get; set; }

		public uint Count { get; set; }

		public override string ToString()
		{
			if (string.IsNullOrEmpty(Reference))
			{
				return base.ToString();
			}
			return base.ToString() + " (" + Reference + ")";
		}

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteValueU32(Pad);
			uint value = Convert.ToUInt32(Reference, 16);
			output.WriteValueU32(value);
			output.WriteValueU32(Count);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Pad = input.ReadValueU32(endian);
			uint num = input.ReadValueU32(endian);
			Reference = $"0x{num:X}";
			Count = input.ReadValueU32();
		}
	}
}
