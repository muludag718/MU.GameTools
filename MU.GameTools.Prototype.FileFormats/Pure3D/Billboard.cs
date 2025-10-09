using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownType(94214u)]
	public class Billboard : BaseNode
	{
		public uint Version { get; set; }

		public string Name { get; set; }

		public string NewShaderName { get; set; }

		public uint CutOffEnabled { get; set; }

		public uint ZTest { get; set; }

		public uint ZWrite { get; set; }

		public uint OcclusionCulling { get; set; }

		public uint NumQuads { get; set; }

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
			output.WriteValueU32(Version, endian);
			output.WriteStringAlignedU8(Name);
			output.WriteStringAlignedU8(NewShaderName);
			output.WriteValueU32(CutOffEnabled, endian);
			output.WriteValueU32(ZTest, endian);
			output.WriteValueU32(ZWrite, endian);
			output.WriteValueU32(OcclusionCulling, endian);
			output.WriteValueU32(NumQuads, endian);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Version = input.ReadValueU32(endian);
			Name = input.ReadStringAlignedU8();
			NewShaderName = input.ReadStringAlignedU8();
			CutOffEnabled = input.ReadValueU32(endian);
			ZTest = input.ReadValueU32(endian);
			ZWrite = input.ReadValueU32(endian);
			OcclusionCulling = input.ReadValueU32(endian);
			NumQuads = input.ReadValueU32(endian);
		}
	}
}
