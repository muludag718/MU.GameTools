using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownType(49283072u)]
	public class AnimationData : BaseNode
	{
		public uint Version { get; set; }

		public string Compression { get; set; }

		public uint UncompressedSize { get; set; }

		public uint CompressedSize { get; set; }

		public byte[] CompressedData { get; set; }

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteValueU32(Version);
			output.WriteString(Compression);
			output.WriteValueU32(UncompressedSize);
			output.WriteValueU32(CompressedSize);
			output.WriteBytes(CompressedData);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Version = input.ReadValueU32(endian);
			Compression = input.ReadString(4);
			UncompressedSize = input.ReadValueU32(endian);
			CompressedSize = input.ReadValueU32(endian);
			CompressedData = input.ReadBytes((int)CompressedSize);
		}
	}
}
