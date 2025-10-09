using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats.Pure3D.Prototype2
{
	[KnownGame(PrototypeGame.P2)]
	[KnownType(65603u)]
	public class P2BufferDescriptor : BaseNode
	{
		public uint AmountOfDescriptions { get; set; }

		public uint DescriptionSize { get; set; }

		public P2Description[] Descriptions { get; set; }

		public override string ToString()
		{
			return "BufferDescriptor";
		}

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteValueU32(AmountOfDescriptions, endian);
			for (uint num = 0u; num < AmountOfDescriptions; num++)
			{
				Descriptions[num].Serialize(output, endian);
			}
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			AmountOfDescriptions = input.ReadValueU32(endian);
			Descriptions = new P2Description[AmountOfDescriptions];
			for (uint num = 0u; num < AmountOfDescriptions; num++)
			{
				Descriptions[num] = new P2Description(input, endian);
			}
			DescriptionSize = Descriptions[0].ItemSize;
		}
	}
}
