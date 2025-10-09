using MU.GameTools.Prototype.FileFormats;
using MU.GameTools.Prototype.FileFormats.Pure3D;
using MU.GameTools.Prototype.FileFormats.Pure3D.Prototype1;

namespace MU.GameTools.Prototype1
{
	internal class Utils
	{
		public static int FindIndexOfDescription(DescriptionTypeEnum descriptionType, VertexDescriptionList vertexDescription)
		{
			for (int i = 0; i < vertexDescription.AmountOfDescriptions; i++)
			{
				if (vertexDescription.Descriptions[i].BufferType.EnumValue == descriptionType)
				{
					return i;
				}
			}
			return -1;
		}

		public static bool IsRawBuffer(PrimitiveGroup primitiveGroup)
		{
			return primitiveGroup.GetChildNodes<RawPositionBuffer>().Count > 0;
		}
	}
}
