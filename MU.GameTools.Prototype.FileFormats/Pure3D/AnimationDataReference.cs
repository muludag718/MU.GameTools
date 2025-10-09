using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownType(1184032u)]
	public class AnimationDataReference : BaseNode
	{
		public uint Version { get; set; }

		public uint Frames { get; set; }

		public uint Offset { get; set; }

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteValueU32(Version);
			output.WriteValueU32(Frames);
			output.WriteValueU32(Offset);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Version = input.ReadValueU32(endian);
			Frames = input.ReadValueU32(endian);
			Offset = input.ReadValueU32(endian);
		}
	}
}
