using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownGame(PrototypeGame.Any)]
	[KnownType(1191936u)]
	[KnownType(151552u)]
	public class CompositeDrawable : BaseNode
	{
		public uint Version { get; set; }

		public string Name { get; set; }

		public string SkeletonName { get; set; }

		public uint NumPrimitives { get; set; }

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
			output.WriteValueU32(Version, endian);
			output.WriteStringAlignedU8(Name);
			output.WriteStringAlignedU8(SkeletonName);
			output.WriteValueU32(NumPrimitives, endian);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Version = input.ReadValueU32(endian);
			Name = input.ReadStringAlignedU8();
			SkeletonName = input.ReadStringAlignedU8();
			NumPrimitives = input.ReadValueU32(endian);
		}
	}
}
