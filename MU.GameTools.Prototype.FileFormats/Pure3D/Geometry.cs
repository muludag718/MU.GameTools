using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownType(65536u)]
	public class Geometry : BaseNode
	{
		public string Name { get; set; }

		public uint Version { get; set; }

		public uint NumPrimitiveGroups { get; set; }

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
			output.WriteValueU32(NumPrimitiveGroups, endian);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Name = input.ReadStringAlignedU8();
			Version = input.ReadValueU32(endian);
			NumPrimitiveGroups = input.ReadValueU32(endian);
		}
	}
}
