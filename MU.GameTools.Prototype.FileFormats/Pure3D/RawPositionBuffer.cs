using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownType(65541u)]
	public class RawPositionBuffer : BaseNode
	{
		public uint BufferSize { get; set; }

		public Vector3[] Position { get; set; }

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteValueU32(BufferSize, endian);
			for (int i = 0; i < Position.Length; i++)
			{
				Position[i].Serialize(output, endian);
			}
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			BufferSize = input.ReadValueU32(endian);
			PrimitiveGroup primitiveGroup = (PrimitiveGroup)ParentNode;
			Position = new Vector3[primitiveGroup.NumVertices];
			for (int i = 0; i < primitiveGroup.NumVertices; i++)
			{
				Position[i] = new Vector3(input, endian);
			}
		}
	}
}
