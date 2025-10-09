using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.FollowFormation)]
	public class FollowFormationTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float TurningVelocity { get; set; }

		public float Acceleration { get; set; }

		public float BrakingDeceleration { get; set; }

		public float ExtraBrakingDistance { get; set; }

		public float LookAhead { get; set; }

		public float MaxVelocity { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(TurningVelocity, endianess);
			output.WriteValueF32(Acceleration, endianess);
			output.WriteValueF32(BrakingDeceleration, endianess);
			output.WriteValueF32(ExtraBrakingDistance, endianess);
			output.WriteValueF32(LookAhead, endianess);
			output.WriteValueF32(MaxVelocity, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			TurningVelocity = input.ReadValueF32(endianess);
			Acceleration = input.ReadValueF32(endianess);
			BrakingDeceleration = input.ReadValueF32(endianess);
			ExtraBrakingDistance = input.ReadValueF32(endianess);
			LookAhead = input.ReadValueF32(endianess);
			MaxVelocity = input.ReadValueF32(endianess);
		}
	}
}
