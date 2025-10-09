using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownType(65543u)]
	public class RawUVBuffer : BaseNode
	{
		public uint BufferSize { get; set; }

		public byte[] Blank { get; set; }

		public UVCoordinate[] UVs { get; set; }

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteValueU32(BufferSize, endian);
			output.WriteBytes(Blank);
			for (int i = 0; i < UVs.Length; i++)
			{
				UVs[i].Serialize(output, endian);
			}
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			BufferSize = input.ReadValueU32(endian);
			Blank = input.ReadBytes(4);
			UVs = new UVCoordinate[BufferSize];
			for (int i = 0; i < BufferSize; i++)
			{
				UVs[i] = new UVCoordinate(input, endian);
			}
		}
	}
}
