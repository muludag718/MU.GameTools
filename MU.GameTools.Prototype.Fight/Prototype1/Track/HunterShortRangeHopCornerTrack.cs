using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.HunterShortRangeHopCorner)]
	public class HunterShortRangeHopCornerTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float VelocityRunUp { get; set; }

		public float VelocityHorizontal { get; set; }

		public float Gravity { get; set; }

		public float OrientationBlendTime { get; set; }

		public float MaxFallSpeed { get; set; }

		public ulong NewSupportingLimb { get; set; }

		public int Priority { get; set; }

		public float BlendInTime { get; set; }

		public float BlendOutTime { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(VelocityRunUp, endianess);
			output.WriteValueF32(VelocityHorizontal, endianess);
			output.WriteValueF32(Gravity, endianess);
			output.WriteValueF32(OrientationBlendTime, endianess);
			output.WriteValueF32(MaxFallSpeed, endianess);
			output.WriteValueU64(NewSupportingLimb, endianess);
			output.WriteValueS32(Priority, endianess);
			output.WriteValueF32(BlendInTime, endianess);
			output.WriteValueF32(BlendOutTime, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			VelocityRunUp = input.ReadValueF32(endianess);
			VelocityHorizontal = input.ReadValueF32(endianess);
			Gravity = input.ReadValueF32(endianess);
			OrientationBlendTime = input.ReadValueF32(endianess);
			MaxFallSpeed = input.ReadValueF32(endianess);
			NewSupportingLimb = input.ReadValueU64(endianess);
			Priority = input.ReadValueS32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
		}
	}
}
