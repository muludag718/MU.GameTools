using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.WallRun)]
	public class WallRunTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float VelocityMin { get; set; }

		public float VelocityMax { get; set; }

		public float Acceleration { get; set; }

		public float Gravity { get; set; }

		public float TurningRate { get; set; }

		public float SurfaceAngleThreshold { get; set; }

		public ulong AnimUp { get; set; }

		public ulong AnimLeft { get; set; }

		public ulong AnimRight { get; set; }

		public ulong AnimUpLeft { get; set; }

		public ulong AnimUpRight { get; set; }

		public ulong AnimDownLeft { get; set; }

		public ulong AnimDownRight { get; set; }

		public bool ForceAnimationVelocities { get; set; }

		public float SyncFrameUp { get; set; }

		public float SyncFrameLeft { get; set; }

		public float SyncFrameRight { get; set; }

		public float SyncFrameUpLeft { get; set; }

		public float SyncFrameUpRight { get; set; }

		public float SyncFrameDownLeft { get; set; }

		public float SyncFrameDownRight { get; set; }

		public float UnlockableVelocityMin { get; set; }

		public UnlockableEnum UnlockableFirst { get; set; }

		public UnlockableEnum UnlockableLast { get; set; }

		public float SprintVelocityDropRate { get; set; }

		public int Priority { get; set; }

		public float BlendInTime { get; set; }

		public float BlendOutTime { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(VelocityMin, endianess);
			output.WriteValueF32(VelocityMax, endianess);
			output.WriteValueF32(Acceleration, endianess);
			output.WriteValueF32(Gravity, endianess);
			output.WriteValueF32(TurningRate, endianess);
			output.WriteValueF32(SurfaceAngleThreshold, endianess);
			output.WriteValueU64(AnimUp, endianess);
			output.WriteValueU64(AnimLeft, endianess);
			output.WriteValueU64(AnimRight, endianess);
			output.WriteValueU64(AnimUpLeft, endianess);
			output.WriteValueU64(AnimUpRight, endianess);
			output.WriteValueU64(AnimDownLeft, endianess);
			output.WriteValueU64(AnimDownRight, endianess);
			output.WriteValueB32(ForceAnimationVelocities, endianess);
			output.WriteValueF32(SyncFrameUp, endianess);
			output.WriteValueF32(SyncFrameLeft, endianess);
			output.WriteValueF32(SyncFrameRight, endianess);
			output.WriteValueF32(SyncFrameUpLeft, endianess);
			output.WriteValueF32(SyncFrameUpRight, endianess);
			output.WriteValueF32(SyncFrameDownLeft, endianess);
			output.WriteValueF32(SyncFrameDownRight, endianess);
			output.WriteValueF32(UnlockableVelocityMin, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, UnlockableFirst);
			BaseProperty.SerializePropertyEnum(output, endianess, UnlockableLast);
			output.WriteValueF32(SprintVelocityDropRate, endianess);
			output.WriteValueS32(Priority, endianess);
			output.WriteValueF32(BlendInTime, endianess);
			output.WriteValueF32(BlendOutTime, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			VelocityMin = input.ReadValueF32(endianess);
			VelocityMax = input.ReadValueF32(endianess);
			Acceleration = input.ReadValueF32(endianess);
			Gravity = input.ReadValueF32(endianess);
			TurningRate = input.ReadValueF32(endianess);
			SurfaceAngleThreshold = input.ReadValueF32(endianess);
			AnimUp = input.ReadValueU64(endianess);
			AnimLeft = input.ReadValueU64(endianess);
			AnimRight = input.ReadValueU64(endianess);
			AnimUpLeft = input.ReadValueU64(endianess);
			AnimUpRight = input.ReadValueU64(endianess);
			AnimDownLeft = input.ReadValueU64(endianess);
			AnimDownRight = input.ReadValueU64(endianess);
			ForceAnimationVelocities = input.ReadValueB32(endianess);
			SyncFrameUp = input.ReadValueF32(endianess);
			SyncFrameLeft = input.ReadValueF32(endianess);
			SyncFrameRight = input.ReadValueF32(endianess);
			SyncFrameUpLeft = input.ReadValueF32(endianess);
			SyncFrameUpRight = input.ReadValueF32(endianess);
			SyncFrameDownLeft = input.ReadValueF32(endianess);
			SyncFrameDownRight = input.ReadValueF32(endianess);
			UnlockableVelocityMin = input.ReadValueF32(endianess);
			UnlockableFirst = BaseProperty.DeserializePropertyEnum<UnlockableEnum>(input, endianess);
			UnlockableLast = BaseProperty.DeserializePropertyEnum<UnlockableEnum>(input, endianess);
			SprintVelocityDropRate = input.ReadValueF32(endianess);
			Priority = input.ReadValueS32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
		}
	}
}
