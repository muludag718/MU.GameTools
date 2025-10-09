using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.PredefinedPatrol)]
	public class PredefinedPatrolTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float FreeRadius { get; set; }

		public float PrimaryLength { get; set; }

		public float SecondaryLength { get; set; }

		public float FreeRadiusPath { get; set; }

		public float DistanceToStartTolerance { get; set; }

		public float DistanceTolerance { get; set; }

		public float MaxPitch { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(FreeRadius, endianess);
			output.WriteValueF32(PrimaryLength, endianess);
			output.WriteValueF32(SecondaryLength, endianess);
			output.WriteValueF32(FreeRadiusPath, endianess);
			output.WriteValueF32(DistanceToStartTolerance, endianess);
			output.WriteValueF32(DistanceTolerance, endianess);
			output.WriteValueF32(MaxPitch, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			FreeRadius = input.ReadValueF32(endianess);
			PrimaryLength = input.ReadValueF32(endianess);
			SecondaryLength = input.ReadValueF32(endianess);
			FreeRadiusPath = input.ReadValueF32(endianess);
			DistanceToStartTolerance = input.ReadValueF32(endianess);
			DistanceTolerance = input.ReadValueF32(endianess);
			MaxPitch = input.ReadValueF32(endianess);
		}
	}
}
