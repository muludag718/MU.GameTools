using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownType(65547u)]
	public class RawUnkownValue : BaseNode
	{
		public uint BufferSize { get; set; }

		public uint[] Data { get; set; }

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteValueU32(BufferSize, endian);
			for (int i = 0; i < BufferSize; i++)
			{
				output.WriteValueU32(Data[i], endian);
			}
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			BufferSize = input.ReadValueU32(endian);
			Data = new uint[BufferSize];
			for (int i = 0; i < BufferSize; i++)
			{
				Data[i] = input.ReadValueU32(endian);
			}
		}
	}
}
