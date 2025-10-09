using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.CirclePatrol)]
	public class CirclePatrolTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float HeightMin { get; set; }

		public float HeightMax { get; set; }

		public float Radius { get; set; }

		public float FreeRadius { get; set; }

		public float AvoidRadius { get; set; }

		public float AvoidCost { get; set; }

		public int Tries { get; set; }

		public float MaxSpeed { get; set; }

		public float MinDistance { get; set; }

		public float MinAngle { get; set; }

		public float MaxPathHeightDiffCurrent { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(HeightMin, endianess);
			output.WriteValueF32(HeightMax, endianess);
			output.WriteValueF32(Radius, endianess);
			output.WriteValueF32(FreeRadius, endianess);
			output.WriteValueF32(AvoidRadius, endianess);
			output.WriteValueF32(AvoidCost, endianess);
			output.WriteValueS32(Tries, endianess);
			output.WriteValueF32(MaxSpeed, endianess);
			output.WriteValueF32(MinDistance, endianess);
			output.WriteValueF32(MinAngle, endianess);
			output.WriteValueF32(MaxPathHeightDiffCurrent, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			HeightMin = input.ReadValueF32(endianess);
			HeightMax = input.ReadValueF32(endianess);
			Radius = input.ReadValueF32(endianess);
			FreeRadius = input.ReadValueF32(endianess);
			AvoidRadius = input.ReadValueF32(endianess);
			AvoidCost = input.ReadValueF32(endianess);
			Tries = input.ReadValueS32(endianess);
			MaxSpeed = input.ReadValueF32(endianess);
			MinDistance = input.ReadValueF32(endianess);
			MinAngle = input.ReadValueF32(endianess);
			MaxPathHeightDiffCurrent = input.ReadValueF32(endianess);
		}
	}
}
