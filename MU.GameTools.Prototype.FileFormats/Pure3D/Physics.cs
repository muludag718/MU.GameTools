using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownGame(PrototypeGame.P1)]
	[KnownType(117571584u)]
	public class Physics : BaseNode
	{
		public string Name { get; set; }

		public uint Unknown2 { get; set; }

		public uint Unknown3 { get; set; }

		public uint Unknown4 { get; set; }

		public override string ToString()
		{
			if (string.IsNullOrEmpty(Name))
			{
				return base.ToString();
			}
			return base.ToString() + " (" + Name.Trim(default(char)) + ")";
		}

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteStringAlignedU8(Name);
			output.WriteValueU32(Unknown2, endian);
			output.WriteValueU32(Unknown3, endian);
			output.WriteValueU32(Unknown4, endian);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Name = input.ReadStringAlignedU8();
			Unknown2 = input.ReadValueU32(endian);
			Unknown3 = input.ReadValueU32(endian);
			Unknown4 = input.ReadValueU32(endian);
		}
	}
}
