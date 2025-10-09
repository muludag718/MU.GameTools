using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.PrepareTightStrafeRun)]
	public class PrepareTightStrafeRunTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float MinSpeed { get; set; }

		public float MaxSpeed { get; set; }

		public float DistanceTolerance { get; set; }

		public float HeightTolerance { get; set; }

		public float ExtraHeightStart { get; set; }

		public float LengthPostStart { get; set; }

		public float WaitTimeAtStart { get; set; }

		public float HeightAtTarget { get; set; }

		public Vector SpeedFactor { get; set; } = new Vector();

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(MinSpeed, endianess);
			output.WriteValueF32(MaxSpeed, endianess);
			output.WriteValueF32(DistanceTolerance, endianess);
			output.WriteValueF32(HeightTolerance, endianess);
			output.WriteValueF32(ExtraHeightStart, endianess);
			output.WriteValueF32(LengthPostStart, endianess);
			output.WriteValueF32(WaitTimeAtStart, endianess);
			output.WriteValueF32(HeightAtTarget, endianess);
			SpeedFactor.Serialize(output, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			MinSpeed = input.ReadValueF32(endianess);
			MaxSpeed = input.ReadValueF32(endianess);
			DistanceTolerance = input.ReadValueF32(endianess);
			HeightTolerance = input.ReadValueF32(endianess);
			ExtraHeightStart = input.ReadValueF32(endianess);
			LengthPostStart = input.ReadValueF32(endianess);
			WaitTimeAtStart = input.ReadValueF32(endianess);
			HeightAtTarget = input.ReadValueF32(endianess);
			SpeedFactor.Deserialize(input, endianess);
		}
	}
}
