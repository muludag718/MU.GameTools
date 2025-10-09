using System;
using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats.Pure3D.Prototype2
{
	[KnownGame(PrototypeGame.P2)]
	[KnownType(65602u)]
	public class P2Buffer : BaseNode
	{
		public uint BufferSize { get; set; }

		public P2BufferDescriptor Description { get; set; }

		public BufferItem[] BufferItems { get; set; }

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteValueU32(BufferSize, endian);
			for (uint num = 0u; num < BufferItems.Length; num++)
			{
				output.WriteBytes(BufferItems[num].Data);
			}
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			BufferSize = input.ReadValueU32(endian);
			Description = ParentNode.GetChildNode<P2BufferDescriptor>();
			P2Primitive p2Primitive = (P2Primitive)ParentNode;
			_ = BufferSize / Description.DescriptionSize;
			_ = Description.AmountOfDescriptions;
			BufferItems = new BufferItem[p2Primitive.NumberOfVertices * Description.AmountOfDescriptions];
			for (int i = 0; i < p2Primitive.NumberOfVertices; i++)
			{
				byte[] array = input.ReadBytes((int)Description.DescriptionSize);
				for (uint num = 0u; num < Description.AmountOfDescriptions; num++)
				{
					uint num2 = ((num + 1 >= Description.AmountOfDescriptions) ? Description.DescriptionSize : Description.Descriptions[num + 1].Offset);
					uint num3 = num2 - Description.Descriptions[num].Offset;
					BufferItem bufferItem = new BufferItem(endian);
					bufferItem.BufferType = Description.Descriptions[num].BufferType;
					bufferItem.Data = new byte[num3];
					for (uint num4 = 0u; num4 < num3; num4++)
					{
						bufferItem.Data[num4] = array[Description.Descriptions[num].Offset + num4];
					}
					if (endian == Endian.Big)
					{
						Array.Reverse(bufferItem.Data);
					}
					BufferItems[i * Description.AmountOfDescriptions + num] = bufferItem;
				}
			}
		}
	}
}
