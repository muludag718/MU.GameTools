using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.JumpAnimation)]
	public class JumpAnimationTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public ulong Animation { get; set; }

		public float Gravity { get; set; }

		public float PeakVerticalVelocity { get; set; }

		public float StartFrameClimb { get; set; }

		public float EndFrameClimb { get; set; }

		public float StartFramePeak { get; set; }

		public float EndFramePeak { get; set; }

		public float StartFrameFall { get; set; }

		public float EndFrameFall { get; set; }

		public bool Spew { get; set; }

		public bool HasRootTranslation { get; set; }

		public bool HasRootRotation { get; set; }

		public ulong Partition { get; set; }

		public int Priority { get; set; }

		public float BlendInTime { get; set; }

		public float BlendOutTime { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueU64(Animation, endianess);
			output.WriteValueF32(Gravity, endianess);
			output.WriteValueF32(PeakVerticalVelocity, endianess);
			output.WriteValueF32(StartFrameClimb, endianess);
			output.WriteValueF32(EndFrameClimb, endianess);
			output.WriteValueF32(StartFramePeak, endianess);
			output.WriteValueF32(EndFramePeak, endianess);
			output.WriteValueF32(StartFrameFall, endianess);
			output.WriteValueF32(EndFrameFall, endianess);
			output.WriteValueB32(Spew, endianess);
			output.WriteValueB32(HasRootTranslation, endianess);
			output.WriteValueB32(HasRootRotation, endianess);
			output.WriteValueU64(Partition, endianess);
			output.WriteValueS32(Priority, endianess);
			output.WriteValueF32(BlendInTime, endianess);
			output.WriteValueF32(BlendOutTime, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Animation = input.ReadValueU64(endianess);
			Gravity = input.ReadValueF32(endianess);
			PeakVerticalVelocity = input.ReadValueF32(endianess);
			StartFrameClimb = input.ReadValueF32(endianess);
			EndFrameClimb = input.ReadValueF32(endianess);
			StartFramePeak = input.ReadValueF32(endianess);
			EndFramePeak = input.ReadValueF32(endianess);
			StartFrameFall = input.ReadValueF32(endianess);
			EndFrameFall = input.ReadValueF32(endianess);
			Spew = input.ReadValueB32(endianess);
			HasRootTranslation = input.ReadValueB32(endianess);
			HasRootRotation = input.ReadValueB32(endianess);
			Partition = input.ReadValueU64(endianess);
			Priority = input.ReadValueS32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
		}
	}
}
