using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.MagneticBootsJump)]
	public class MagneticBootsJumpTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float FlightTime { get; set; }

		public float UpDistance { get; set; }

		public float ForwardDistance { get; set; }

		public float MaxFallSpeed { get; set; }

		public int ChoreoPriority { get; set; }

		public float BlendInTime { get; set; }

		public float BlendOutTime { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(FlightTime, endianess);
			output.WriteValueF32(UpDistance, endianess);
			output.WriteValueF32(ForwardDistance, endianess);
			output.WriteValueF32(MaxFallSpeed, endianess);
			output.WriteValueS32(ChoreoPriority, endianess);
			output.WriteValueF32(BlendInTime, endianess);
			output.WriteValueF32(BlendOutTime, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			FlightTime = input.ReadValueF32(endianess);
			UpDistance = input.ReadValueF32(endianess);
			ForwardDistance = input.ReadValueF32(endianess);
			MaxFallSpeed = input.ReadValueF32(endianess);
			ChoreoPriority = input.ReadValueS32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
		}
	}
}
