using MU.GameTools.Prototype.FileFormats;
using MU.GameTools.Prototype.FileFormats.Pure3D.Prototype2;

namespace MU.GameTools.Prototype2
{
	public static class Utils
	{
		public static int FindIndexOfDescription(DescriptionTypeEnum descriptionType, P2BufferDescriptor vertexDescription)
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
	}
}
