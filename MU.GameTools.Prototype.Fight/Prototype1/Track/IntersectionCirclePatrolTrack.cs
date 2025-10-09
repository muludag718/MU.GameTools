using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.IntersectionCirclePatrol)]
	public class IntersectionCirclePatrolTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float HeightMin { get; set; }

		public float HeightMinFromTarget { get; set; }

		public float MinDistance { get; set; }

		public float Radius { get; set; }

		public float FreeRadiusPath { get; set; }

		public float FreeRadius { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(HeightMin, endianess);
			output.WriteValueF32(HeightMinFromTarget, endianess);
			output.WriteValueF32(MinDistance, endianess);
			output.WriteValueF32(Radius, endianess);
			output.WriteValueF32(FreeRadiusPath, endianess);
			output.WriteValueF32(FreeRadius, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			HeightMin = input.ReadValueF32(endianess);
			HeightMinFromTarget = input.ReadValueF32(endianess);
			MinDistance = input.ReadValueF32(endianess);
			Radius = input.ReadValueF32(endianess);
			FreeRadiusPath = input.ReadValueF32(endianess);
			FreeRadius = input.ReadValueF32(endianess);
		}
	}
}
