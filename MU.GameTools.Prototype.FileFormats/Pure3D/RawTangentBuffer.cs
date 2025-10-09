using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownType(65576u)]
	public class RawTangentBuffer : BaseNode
	{
		public uint BufferSize { get; set; }

		public Vector4[] Tangents { get; set; }

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteValueU32(BufferSize, endian);
			for (int i = 0; i < Tangents.Length; i++)
			{
				Tangents[i].Serialize(output, endian);
			}
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			BufferSize = input.ReadValueU32(endian);
			Tangents = new Vector4[BufferSize];
			for (int i = 0; i < BufferSize; i++)
			{
				Tangents[i] = new Vector4(input, endian);
			}
		}
	}
}
