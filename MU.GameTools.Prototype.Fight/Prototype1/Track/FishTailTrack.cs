using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.FishTail)]
	public class FishTailTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float MinTimeDelay { get; set; }

		public float MaxTimeDelay { get; set; }

		public float Turning { get; set; }

		public float DesiredVelocity { get; set; }

		public float Accelration { get; set; }

		public float Braking { get; set; }

		public float SkidSeverity { get; set; }

		public float FishTailSeverity { get; set; }

		public BranchReference MyBranch { get; set; } = new BranchReference();

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(MinTimeDelay, endianess);
			output.WriteValueF32(MaxTimeDelay, endianess);
			output.WriteValueF32(Turning, endianess);
			output.WriteValueF32(DesiredVelocity, endianess);
			output.WriteValueF32(Accelration, endianess);
			output.WriteValueF32(Braking, endianess);
			output.WriteValueF32(SkidSeverity, endianess);
			output.WriteValueF32(FishTailSeverity, endianess);
			MyBranch.Serialize(output, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			MinTimeDelay = input.ReadValueF32(endianess);
			MaxTimeDelay = input.ReadValueF32(endianess);
			Turning = input.ReadValueF32(endianess);
			DesiredVelocity = input.ReadValueF32(endianess);
			Accelration = input.ReadValueF32(endianess);
			Braking = input.ReadValueF32(endianess);
			SkidSeverity = input.ReadValueF32(endianess);
			FishTailSeverity = input.ReadValueF32(endianess);
			MyBranch.Deserialize(input, endianess);
		}
	}
}
