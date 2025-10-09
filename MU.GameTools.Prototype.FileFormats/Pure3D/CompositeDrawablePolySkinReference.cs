using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownType(1191937u)]
	public class CompositeDrawablePolySkinReference : BaseNode
	{
		public uint Unknown1 { get; set; }

		public uint Unknown2 { get; set; }

		public string PolySkinName { get; set; }

		public uint Unknown4 { get; set; }

		public uint Unknown5 { get; set; }

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteValueU32(Unknown1, endian);
			output.WriteValueU32(Unknown2, endian);
			output.WriteStringAlignedU8(PolySkinName);
			output.WriteValueU32(Unknown4, endian);
			output.WriteValueU32(Unknown5, endian);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Unknown1 = input.ReadValueU32(endian);
			Unknown2 = input.ReadValueU32(endian);
			PolySkinName = input.ReadStringAlignedU8();
			Unknown4 = input.ReadValueU32(endian);
			Unknown5 = input.ReadValueU32(endian);
		}
	}
}
