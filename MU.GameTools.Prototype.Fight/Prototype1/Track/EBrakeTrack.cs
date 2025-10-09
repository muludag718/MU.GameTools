using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	public class EBrakeTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float MinTimeDelay { get; set; }

		public float MaxTimeDelay { get; set; }

		public float TurningSpeed { get; set; }

		public float Braking { get; set; }

		public float TurningAmount { get; set; }

		public float SkidSeverity { get; set; }

		public BranchReference MyBranch { get; set; } = new BranchReference();

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(MinTimeDelay, endianess);
			output.WriteValueF32(MaxTimeDelay, endianess);
			output.WriteValueF32(TurningSpeed, endianess);
			output.WriteValueF32(Braking, endianess);
			output.WriteValueF32(TurningAmount, endianess);
			output.WriteValueF32(SkidSeverity, endianess);
			MyBranch.Serialize(output, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			MinTimeDelay = input.ReadValueF32(endianess);
			MaxTimeDelay = input.ReadValueF32(endianess);
			TurningSpeed = input.ReadValueF32(endianess);
			Braking = input.ReadValueF32(endianess);
			TurningAmount = input.ReadValueF32(endianess);
			SkidSeverity = input.ReadValueF32(endianess);
			MyBranch.Deserialize(input, endianess);
		}
	}
}
