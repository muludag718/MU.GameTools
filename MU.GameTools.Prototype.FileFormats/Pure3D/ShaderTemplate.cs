using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownType(69641u)]
	public class ShaderTemplate : BaseNode
	{
		public string Name { get; set; }

		public uint Unknown02 { get; set; }

		public uint NumPasses { get; set; }

		public uint Unknown04 { get; set; }

		public uint Unknown05 { get; set; }

		public uint NumFloat2 { get; set; }

		public uint Unknown07 { get; set; }

		public uint Unknown08 { get; set; }

		public uint Unknown09 { get; set; }

		public uint NumFloat3 { get; set; }

		public uint Unknown11 { get; set; }

		public uint Unknown12 { get; set; }

		public uint NumFloat4 { get; set; }

		public uint NumMatrices { get; set; }

		public uint NumBools { get; set; }

		public uint Unknown16 { get; set; }

		public override string ToString()
		{
			if (string.IsNullOrEmpty(Name))
			{
				return base.ToString();
			}
			return base.ToString() + " (" + Name + ")";
		}

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteStringAlignedU8(Name);
			output.WriteValueU32(Unknown02, endian);
			output.WriteValueU32(NumPasses, endian);
			output.WriteValueU32(Unknown04, endian);
			output.WriteValueU32(Unknown05, endian);
			output.WriteValueU32(NumFloat2, endian);
			output.WriteValueU32(Unknown07, endian);
			output.WriteValueU32(Unknown08, endian);
			output.WriteValueU32(Unknown09, endian);
			output.WriteValueU32(NumFloat3, endian);
			output.WriteValueU32(Unknown11, endian);
			output.WriteValueU32(Unknown12, endian);
			output.WriteValueU32(NumFloat4, endian);
			output.WriteValueU32(NumMatrices, endian);
			output.WriteValueU32(NumBools, endian);
			output.WriteValueU32(Unknown16, endian);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Name = input.ReadStringAlignedU8();
			Unknown02 = input.ReadValueU32(endian);
			NumPasses = input.ReadValueU32(endian);
			Unknown04 = input.ReadValueU32(endian);
			Unknown05 = input.ReadValueU32(endian);
			NumFloat2 = input.ReadValueU32(endian);
			Unknown07 = input.ReadValueU32(endian);
			Unknown08 = input.ReadValueU32(endian);
			Unknown09 = input.ReadValueU32(endian);
			NumFloat3 = input.ReadValueU32(endian);
			Unknown11 = input.ReadValueU32(endian);
			Unknown12 = input.ReadValueU32(endian);
			NumFloat4 = input.ReadValueU32(endian);
			NumMatrices = input.ReadValueU32(endian);
			NumBools = input.ReadValueU32(endian);
			Unknown16 = input.ReadValueU32(endian);
		}
	}
}
