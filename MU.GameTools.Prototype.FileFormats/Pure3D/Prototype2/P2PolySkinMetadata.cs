using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats.Pure3D.Prototype2
{
	[KnownGame(PrototypeGame.P2)]
	[KnownType(151554u)]
	[KnownType(151555u)]
	public class P2PolySkinMetadata : BaseNode
	{
		public uint Unknown1 { get; set; }

		public string ShaderName { get; set; }

		public uint Unknown2 { get; set; }

		public string IndicesName { get; set; }

		public string VerticesName { get; set; }

		public string SkinName { get; set; }

		public byte Unknown3 { get; set; }

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteValueU32(Unknown1, endian);
			output.WriteStringAlignedU8(ShaderName);
			output.WriteValueU32(Unknown2, endian);
			output.WriteStringAlignedU8(IndicesName);
			output.WriteStringAlignedU8(VerticesName);
			output.WriteStringAlignedU8(SkinName);
			output.WriteByte(Unknown3);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Unknown1 = input.ReadValueU32(endian);
			ShaderName = input.ReadStringAlignedU8();
			Unknown2 = input.ReadValueU32(endian);
			IndicesName = input.ReadStringAlignedU8();
			VerticesName = input.ReadStringAlignedU8();
			SkinName = input.ReadStringAlignedU8();
			Unknown3 = (byte)input.ReadByte();
		}
	}
}
