using System.ComponentModel;
using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats.Pure3D.Prototype1
{
	[KnownGame(PrototypeGame.P1)]
	[KnownType(65556u)]
	public class VertexDescriptionList : BaseNode
	{
		public uint Version { get; set; }

		public uint Param { get; set; }

		[ReadOnly(true)]
		public uint BufferSize { get; set; }

		[ReadOnly(true)]
		public uint DescriptionSize { get; set; }

		[ReadOnly(true)]
		public uint AmountOfDescriptions { get; set; }

		[ReadOnly(true)]
		public uint VertexObjectSize => Descriptions[0].VertexObjectSize;

		public VertexDescription[] Descriptions { get; set; }

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteValueU32(Version, endian);
			output.WriteValueU32(Param, endian);
			output.WriteValueU32(BufferSize, endian);
			output.WriteValueU32(DescriptionSize, endian);
			for (uint num = 0u; num < AmountOfDescriptions; num++)
			{
				Descriptions[num].Serialize(output, endian);
			}
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Version = input.ReadValueU32(endian);
			Param = input.ReadValueU32(endian);
			BufferSize = input.ReadValueU32(endian);
			DescriptionSize = input.ReadValueU32(endian);
			AmountOfDescriptions = DescriptionSize / 17;
			Descriptions = new VertexDescription[AmountOfDescriptions];
			for (uint num = 0u; num < AmountOfDescriptions; num++)
			{
				Descriptions[num] = new VertexDescription(input, endian);
			}
		}
	}
}
