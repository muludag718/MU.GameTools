using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.TankRam)]
	public class TankRamTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float TimePreparingForward { get; set; }

		public float TimePreparingBackward { get; set; }

		public float MaxTurningSpeedFactor { get; set; }

		public float RollingScaleFactor { get; set; }

		public float RollingScaleBackwardsFactor { get; set; }

		public float RollingScaleFactorPush { get; set; }

		public float RollingScaleBackwardsFactorPush { get; set; }

		public float ToleranceForward { get; set; }

		public float Speed { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(TimePreparingForward, endianess);
			output.WriteValueF32(TimePreparingBackward, endianess);
			output.WriteValueF32(MaxTurningSpeedFactor, endianess);
			output.WriteValueF32(RollingScaleFactor, endianess);
			output.WriteValueF32(RollingScaleBackwardsFactor, endianess);
			output.WriteValueF32(RollingScaleFactorPush, endianess);
			output.WriteValueF32(RollingScaleBackwardsFactorPush, endianess);
			output.WriteValueF32(ToleranceForward, endianess);
			output.WriteValueF32(Speed, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			TimePreparingForward = input.ReadValueF32(endianess);
			TimePreparingBackward = input.ReadValueF32(endianess);
			MaxTurningSpeedFactor = input.ReadValueF32(endianess);
			RollingScaleFactor = input.ReadValueF32(endianess);
			RollingScaleBackwardsFactor = input.ReadValueF32(endianess);
			RollingScaleFactorPush = input.ReadValueF32(endianess);
			RollingScaleBackwardsFactorPush = input.ReadValueF32(endianess);
			ToleranceForward = input.ReadValueF32(endianess);
			Speed = input.ReadValueF32(endianess);
		}
	}
}
