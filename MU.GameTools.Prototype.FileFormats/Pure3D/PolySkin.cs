using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownGame(PrototypeGame.P1)]
	[KnownType(65537u)]
	public class PolySkin : BaseNode
	{
		public string Name { get; set; }

		public uint Version { get; set; }

		public string SkeletonName { get; set; }

		public uint PrimitiveGroup { get; set; }

		public override string ToString()
		{
			if (!string.IsNullOrEmpty(Name))
			{
				return base.ToString() + " (" + Name.Trim(default(char)) + ")";
			}
			return base.ToString();
		}

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteStringAlignedU8(Name);
			output.WriteValueU32(Version, endian);
			output.WriteStringAlignedU8(SkeletonName);
			output.WriteValueU32(PrimitiveGroup, endian);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Name = input.ReadStringAlignedU8();
			Version = input.ReadValueU32(endian);
			SkeletonName = input.ReadStringAlignedU8();
			PrimitiveGroup = input.ReadValueU32(endian);
		}
	}
}
