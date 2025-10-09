using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownGame(PrototypeGame.Any)]
	[KnownType(143360u)]
	public class Skeleton : BaseNode
	{
		public string Name { get; set; }

		public uint Version { get; set; }

		public uint NumJoints { get; set; }

		public uint NumPartitions { get; set; }

		public uint NumLimbs { get; set; }

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
			output.WriteValueU32(Version, endian);
			output.WriteValueU32(NumJoints, endian);
			output.WriteValueU32(NumPartitions, endian);
			output.WriteValueU32(NumLimbs, endian);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Name = input.ReadStringAlignedU8();
			Version = input.ReadValueU32(endian);
			NumJoints = input.ReadValueU32(endian);
			NumPartitions = input.ReadValueU32(endian);
			NumLimbs = input.ReadValueU32(endian);
		}
	}
}
