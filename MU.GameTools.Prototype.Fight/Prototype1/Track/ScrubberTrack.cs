using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.Scrubber)]
	public class ScrubberTrack : P1Track
	{
		public ulong Animation { get; set; }

		public float Frame { get; set; }

		public float FrameOffset { get; set; }

		public bool HasRootTranslation { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueU64(Animation, endianess);
			output.WriteValueF32(Frame, endianess);
			output.WriteValueF32(FrameOffset, endianess);
			output.WriteValueB32(HasRootTranslation, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Animation = input.ReadValueU64(endianess);
			Frame = input.ReadValueF32(endianess);
			FrameOffset = input.ReadValueF32(endianess);
			HasRootTranslation = input.ReadValueB32(endianess);
		}
	}
}
