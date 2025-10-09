using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownType(1184016u)]
	public class InterpolationChannel : BaseNode
	{
		public uint Version { get; set; }

		public float Interpolate { get; set; }

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteValueU32(Version);
			output.WriteValueF32(Interpolate);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Version = input.ReadValueU32(endian);
			Interpolate = input.ReadValueF32(endian);
		}
	}
}
