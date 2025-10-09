using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats.Pure3D.Prototype2
{
	[KnownGame(PrototypeGame.P2)]
	[KnownType(65601u)]
	[KnownType(65600u)]
	public class P2Primitive : BaseNode
	{
		public uint Version { get; set; }

		public string Name { get; set; }

		public uint Unknown1 { get; set; }

		public uint Unknown2 { get; set; }

		public uint NumberOfVertices { get; set; }

		public uint Unknown3 { get; set; }

		public uint Unknown4 { get; set; }

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
			output.WriteValueU32(Unknown1, endian);
			output.WriteValueU32(Unknown2, endian);
			output.WriteValueU32(NumberOfVertices, endian);
			output.WriteValueU32(Unknown3, endian);
			output.WriteValueU32(Unknown4, endian);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Version = input.ReadValueU32(endian);
			Name = input.ReadStringAlignedU8();
			Unknown1 = input.ReadValueU32(endian);
			Unknown2 = input.ReadValueU32(endian);
			NumberOfVertices = input.ReadValueU32(endian);
			Unknown3 = input.ReadValueU32(endian);
			Unknown4 = input.ReadValueU32(endian);
		}
	}
}
