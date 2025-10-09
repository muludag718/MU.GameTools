using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownType(65546u)]
	public class RawIndexBuffer : BaseNode
	{
		public uint BufferSize { get; set; }

		public Vector3Int[] Faces { get; set; }

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteValueU32(BufferSize, endian);
			for (int i = 0; i < Faces.Length; i++)
			{
				Faces[i].Serialize(output, endian);
			}
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			BufferSize = input.ReadValueU32(endian);
			uint num = BufferSize / 3;
			Faces = new Vector3Int[num];
			for (int i = 0; i < num; i++)
			{
				Faces[i] = new Vector3Int(input, endian);
			}
		}
	}
}
