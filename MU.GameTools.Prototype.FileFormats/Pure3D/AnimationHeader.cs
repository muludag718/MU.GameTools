using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownType(1183750u)]
	public class AnimationHeader : BaseNode
	{
		public uint Unknown1 { get; set; }

		public uint NumberOfAnimationBones { get; set; }

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteValueU32(Unknown1, endian);
			output.WriteValueU32(NumberOfAnimationBones, endian);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Unknown1 = input.ReadValueU32(endian);
			NumberOfAnimationBones = input.ReadValueU32(endian);
		}
	}
}
