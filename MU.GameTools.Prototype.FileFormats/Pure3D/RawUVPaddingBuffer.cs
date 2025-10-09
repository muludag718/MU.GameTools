using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownType(65544u)]
	public class RawUVPaddingBuffer : BaseNode
	{
		public uint BufferSize { get; set; }

		public uint[] Padding { get; set; }

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteValueU32(BufferSize, endian);
			for (int i = 0; i < Padding.Length; i++)
			{
				output.WriteValueU32(Padding[i], endian);
			}
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			BufferSize = input.ReadValueU32(endian);
			Padding = new uint[BufferSize];
			for (int i = 0; i < BufferSize; i++)
			{
				Padding[i] = input.ReadValueU32(endian);
			}
		}
	}
}
