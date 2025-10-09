using System.IO;
using System.Runtime.Serialization;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats.Pure3D.Prototype2
{
	[DataContract(Namespace = "http://datacontract.gib.me/prototype")]
	public class P2Description
	{
		public DescriptionType BufferType { get; set; }

		public uint Unknown1 { get; set; }

		public uint Unknown2 { get; set; }

		public uint Offset { get; set; }

		public uint ItemSize { get; set; }

		public uint BufferSize { get; set; }

		public uint Unknown5 { get; set; }

		public uint Unknown6 { get; set; }

		public P2Description()
		{
		}

		public P2Description(Stream input, Endian endian)
		{
			Deserialize(input, endian);
		}

		public void Serialize(Stream output, Endian endian)
		{
			output.WriteStringAlignedU8(BufferType.ToP2Type());
			output.WriteValueU32(Unknown1, endian);
			output.WriteValueU32(Unknown2, endian);
			output.WriteValueU32(Offset, endian);
			output.WriteValueU32(ItemSize, endian);
			output.WriteValueU32(BufferSize, endian);
			output.WriteValueU32(Unknown5, endian);
			output.WriteValueU32(Unknown6, endian);
		}

		public void Deserialize(Stream input, Endian endian)
		{
			BufferType = new DescriptionType(input.ReadStringAlignedU8());
			Unknown1 = input.ReadValueU32(endian);
			Unknown2 = input.ReadValueU32(endian);
			Offset = input.ReadValueU32(endian);
			ItemSize = input.ReadValueU32(endian);
			BufferSize = input.ReadValueU32(endian);
			Unknown5 = input.ReadValueU32(endian);
			Unknown6 = input.ReadValueU32(endian);
		}
	}
}
