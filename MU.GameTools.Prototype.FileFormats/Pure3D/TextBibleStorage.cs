using System.ComponentModel;
using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownType(98817u)]
	public class TextBibleStorage : BaseNode
	{
		public string Unknown1 { get; set; }

		public uint Unknown2 { get; set; }

		[ReadOnly(true)]
		public byte[] Data { get; set; }

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteStringAlignedU8(Unknown1);
			output.WriteValueU32(Unknown2, endian);
			output.WriteValueU32((uint)Data.Length, endian);
			output.Write(Data, 0, Data.Length);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Unknown1 = input.ReadStringAlignedU8();
			Unknown2 = input.ReadValueU32(endian);
			uint num = input.ReadValueU32(endian);
			Data = new byte[num];
			input.Read(Data, 0, Data.Length);
		}
	}
}
