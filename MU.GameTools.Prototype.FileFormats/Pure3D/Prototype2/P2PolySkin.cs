using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats.Pure3D.Prototype2
{
	[KnownGame(PrototypeGame.P2)]
	[KnownType(151553u)]
	public class P2PolySkin : BaseNode
	{
		public uint Unknown1 { get; set; }

		public uint Unknown2 { get; set; }

		public string Name { get; set; }

		public override string ToString()
		{
			if (!string.IsNullOrEmpty(Name))
			{
				return "PolySkin (" + Name.Trim(default(char)) + ")";
			}
			return "PolySkin";
		}

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteValueU32(Unknown1, endian);
			output.WriteValueU32(Unknown2, endian);
			output.WriteStringAlignedU8(Name);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Unknown1 = input.ReadValueU32(endian);
			Unknown2 = input.ReadValueU32(endian);
			Name = input.ReadStringAlignedU8();
		}
	}
}
