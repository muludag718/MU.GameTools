using System.ComponentModel;
using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats.Pure3D.Prototype1
{
	[KnownGame(PrototypeGame.P1)]
	[KnownType(65554u)]
	public class VertexBuffer : BaseNode
	{
		public uint Version { get; set; }

		public uint Param { get; set; }

		[ReadOnly(true)]
		public uint BufferSize { get; set; }

		public BufferItem[] BufferItems { get; set; }

		public VertexDescriptionList Description { get; set; }

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteValueU32(Version, endian);
			output.WriteValueU32(Param, endian);
			output.WriteValueU32(BufferSize, endian);
			for (uint num = 0u; num < BufferItems.Length; num++)
			{
				output.WriteBytes(BufferItems[num].Data);
			}
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Version = input.ReadValueU32(endian);
			Param = input.ReadValueU32(endian);
			BufferSize = input.ReadValueU32(endian);
			VertexDescriptionList vertexDescriptionList = (Description = ParentNode.GetChildNodes<VertexDescriptionList>().Find((VertexDescriptionList x) => x.Param == Param));
			uint num = BufferSize / vertexDescriptionList.VertexObjectSize;
			BufferItems = new BufferItem[num * vertexDescriptionList.AmountOfDescriptions];
			for (uint num2 = 0u; num2 < num; num2++)
			{
				byte[] array = input.ReadBytes((int)vertexDescriptionList.VertexObjectSize);
				for (uint num3 = 0u; num3 < vertexDescriptionList.AmountOfDescriptions; num3++)
				{
					uint num4 = ((num3 + 1 >= vertexDescriptionList.AmountOfDescriptions) ? vertexDescriptionList.VertexObjectSize : vertexDescriptionList.Descriptions[num3 + 1].Offset);
					uint num5 = num4 - vertexDescriptionList.Descriptions[num3].Offset;
					BufferItem bufferItem = new BufferItem(endian);
					bufferItem.BufferType = vertexDescriptionList.Descriptions[num3].BufferType;
					bufferItem.Data = new byte[num5];
					for (uint num6 = 0u; num6 < num5; num6++)
					{
						bufferItem.Data[num6] = array[vertexDescriptionList.Descriptions[num3].Offset + num6];
					}
					BufferItems[num2 * vertexDescriptionList.AmountOfDescriptions + num3] = bufferItem;
				}
			}
		}
	}
}
