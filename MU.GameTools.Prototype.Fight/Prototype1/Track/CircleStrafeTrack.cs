using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.CircleStrafe)]
	public class CircleStrafeTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float DistanceMin { get; set; }

		public float DistanceMax { get; set; }

		public float HeightMin { get; set; }

		public float HeightMax { get; set; }

		public float SafeHeight { get; set; }

		public float MinSpeed { get; set; }

		public float MaxSpeed { get; set; }

		public float ShootingDistance { get; set; }

		public bool UseMissiles { get; set; }

		public float MinFireTime { get; set; }

		public float MaxFireTime { get; set; }

		public float MinWaitTime { get; set; }

		public float MaxWaitTime { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(DistanceMin, endianess);
			output.WriteValueF32(DistanceMax, endianess);
			output.WriteValueF32(HeightMin, endianess);
			output.WriteValueF32(HeightMax, endianess);
			output.WriteValueF32(SafeHeight, endianess);
			output.WriteValueF32(MinSpeed, endianess);
			output.WriteValueF32(MaxSpeed, endianess);
			output.WriteValueF32(ShootingDistance, endianess);
			output.WriteValueB32(UseMissiles, endianess);
			output.WriteValueF32(MinFireTime, endianess);
			output.WriteValueF32(MaxFireTime, endianess);
			output.WriteValueF32(MinWaitTime, endianess);
			output.WriteValueF32(MaxWaitTime, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			DistanceMin = input.ReadValueF32(endianess);
			DistanceMax = input.ReadValueF32(endianess);
			HeightMin = input.ReadValueF32(endianess);
			HeightMax = input.ReadValueF32(endianess);
			SafeHeight = input.ReadValueF32(endianess);
			MinSpeed = input.ReadValueF32(endianess);
			MaxSpeed = input.ReadValueF32(endianess);
			ShootingDistance = input.ReadValueF32(endianess);
			UseMissiles = input.ReadValueB32(endianess);
			MinFireTime = input.ReadValueF32(endianess);
			MaxFireTime = input.ReadValueF32(endianess);
			MinWaitTime = input.ReadValueF32(endianess);
			MaxWaitTime = input.ReadValueF32(endianess);
		}
	}
}
