using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.GroundSlide)]
	public class GroundSlideTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float Facing { get; set; }

		public float Deceleration { get; set; }

		public float MinInitVelocity { get; set; }

		public float MinVelocity { get; set; }

		public float MaxVelocity { get; set; }

		public int Priority { get; set; }

		public float BlendInTime { get; set; }

		public float BlendOutTime { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(Facing, endianess);
			output.WriteValueF32(Deceleration, endianess);
			output.WriteValueF32(MinInitVelocity, endianess);
			output.WriteValueF32(MinVelocity, endianess);
			output.WriteValueF32(MaxVelocity, endianess);
			output.WriteValueS32(Priority, endianess);
			output.WriteValueF32(BlendInTime, endianess);
			output.WriteValueF32(BlendOutTime, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Facing = input.ReadValueF32(endianess);
			Deceleration = input.ReadValueF32(endianess);
			MinInitVelocity = input.ReadValueF32(endianess);
			MinVelocity = input.ReadValueF32(endianess);
			MaxVelocity = input.ReadValueF32(endianess);
			Priority = input.ReadValueS32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
		}
	}
}
