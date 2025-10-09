using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.LocoSteerLean)]
	public class LocoSteerLeanTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float Acceleration { get; set; }

		public float TurningVelocity { get; set; }

		public float VelocityWalk { get; set; }

		public float VelocityRun { get; set; }

		public float LeanAngleThreshold { get; set; }

		public float LeanRateIn { get; set; }

		public float LeanRateOut { get; set; }

		public bool UseWorldCoordinates { get; set; }

		public float Phase { get; set; }

		public ulong Locomotion { get; set; }

		public ulong AnimIdle { get; set; }

		public ulong AnimWalk { get; set; }

		public ulong AnimWalkLeanEast { get; set; }

		public ulong AnimWalkLeanWest { get; set; }

		public ulong AnimRun { get; set; }

		public ulong AnimRunLeanEast { get; set; }

		public ulong AnimRunLeanWest { get; set; }

		public float SyncFrameIdle { get; set; }

		public float SyncFrameWalk { get; set; }

		public float SyncFrameWalkLeanEast { get; set; }

		public float SyncFrameWalkLeanWest { get; set; }

		public float SyncFrameRun { get; set; }

		public float SyncFrameRunLeanEast { get; set; }

		public float SyncFrameRunLeanWest { get; set; }

		public ulong Partition { get; set; }

		public int Priority { get; set; }

		public float BlendInTime { get; set; }

		public float BlendOutTime { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(Acceleration, endianess);
			output.WriteValueF32(TurningVelocity, endianess);
			output.WriteValueF32(VelocityWalk, endianess);
			output.WriteValueF32(VelocityRun, endianess);
			output.WriteValueF32(LeanAngleThreshold, endianess);
			output.WriteValueF32(LeanRateIn, endianess);
			output.WriteValueF32(LeanRateOut, endianess);
			output.WriteValueB32(UseWorldCoordinates, endianess);
			output.WriteValueF32(Phase, endianess);
			output.WriteValueU64(Locomotion, endianess);
			output.WriteValueU64(AnimIdle, endianess);
			output.WriteValueU64(AnimWalk, endianess);
			output.WriteValueU64(AnimWalkLeanEast, endianess);
			output.WriteValueU64(AnimWalkLeanWest, endianess);
			output.WriteValueU64(AnimRun, endianess);
			output.WriteValueU64(AnimRunLeanEast, endianess);
			output.WriteValueU64(AnimRunLeanWest, endianess);
			output.WriteValueF32(SyncFrameIdle, endianess);
			output.WriteValueF32(SyncFrameWalk, endianess);
			output.WriteValueF32(SyncFrameWalkLeanEast, endianess);
			output.WriteValueF32(SyncFrameWalkLeanWest, endianess);
			output.WriteValueF32(SyncFrameRun, endianess);
			output.WriteValueF32(SyncFrameRunLeanEast, endianess);
			output.WriteValueF32(SyncFrameRunLeanWest, endianess);
			output.WriteValueU64(Partition, endianess);
			output.WriteValueS32(Priority, endianess);
			output.WriteValueF32(BlendInTime, endianess);
			output.WriteValueF32(BlendOutTime, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Acceleration = input.ReadValueF32(endianess);
			TurningVelocity = input.ReadValueF32(endianess);
			VelocityWalk = input.ReadValueF32(endianess);
			VelocityRun = input.ReadValueF32(endianess);
			LeanAngleThreshold = input.ReadValueF32(endianess);
			LeanRateIn = input.ReadValueF32(endianess);
			LeanRateOut = input.ReadValueF32(endianess);
			UseWorldCoordinates = input.ReadValueB32(endianess);
			Phase = input.ReadValueF32(endianess);
			Locomotion = input.ReadValueU64(endianess);
			AnimIdle = input.ReadValueU64(endianess);
			AnimWalk = input.ReadValueU64(endianess);
			AnimWalkLeanEast = input.ReadValueU64(endianess);
			AnimWalkLeanWest = input.ReadValueU64(endianess);
			AnimRun = input.ReadValueU64(endianess);
			AnimRunLeanEast = input.ReadValueU64(endianess);
			AnimRunLeanWest = input.ReadValueU64(endianess);
			SyncFrameIdle = input.ReadValueF32(endianess);
			SyncFrameWalk = input.ReadValueF32(endianess);
			SyncFrameWalkLeanEast = input.ReadValueF32(endianess);
			SyncFrameWalkLeanWest = input.ReadValueF32(endianess);
			SyncFrameRun = input.ReadValueF32(endianess);
			SyncFrameRunLeanEast = input.ReadValueF32(endianess);
			SyncFrameRunLeanWest = input.ReadValueF32(endianess);
			Partition = input.ReadValueU64(endianess);
			Priority = input.ReadValueS32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
		}
	}
}
