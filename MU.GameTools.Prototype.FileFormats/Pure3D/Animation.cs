using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[KnownGame(PrototypeGame.Any)]
	[KnownType(1183744u)]
	public class Animation : BaseNode
	{
		public uint Version { get; set; }

		public string Name { get; set; }

		public string AnimationType { get; set; }

		public float NumFrames { get; set; }

		public float FrameRate { get; set; }

		public uint Cyclic { get; set; }

		public override string ToString()
		{
			if (string.IsNullOrEmpty(Name))
			{
				return base.ToString();
			}
			return base.ToString() + " (" + Name.Trim(default(char)) + ")";
		}

		public override void Serialize(Stream output, Endian endian)
		{
			output.WriteValueU32(Version, endian);
			output.WriteStringAlignedU8(Name);
			output.WriteString(AnimationType);
			output.WriteValueF32(NumFrames, endian);
			output.WriteValueF32(FrameRate, endian);
			output.WriteValueU32(Cyclic, endian);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			Version = input.ReadValueU32(endian);
			Name = input.ReadStringAlignedU8();
			AnimationType = input.ReadString(4);
			NumFrames = input.ReadValueF32(endian);
			FrameRate = input.ReadValueF32(endian);
			Cyclic = input.ReadValueU32(endian);
		}
	}
}
