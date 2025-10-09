using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;
using MU.GameTools.Prototype.Fight.Property;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.LocoCrowd)]
	public class LocoCrowdTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float Acceleration { get; set; }

		public float TurningVelocity { get; set; }

		public float TwistRateOn { get; set; }

		public float TwistRateOff { get; set; }

		public float VelocityWalk { get; set; }

		public float VelocityRun { get; set; }

		public float SmoothSteeringAngle { get; set; }

		public float Phase { get; set; }

		public ulong Locomotion { get; set; }

		public ulong AnimIdle { get; set; }

		public ulong AnimIdleTwistLeft { get; set; }

		public ulong AnimIdleTwistRight { get; set; }

		public ulong AnimWalk { get; set; }

		public ulong AnimWalkTwistLeft { get; set; }

		public ulong AnimWalkTwistRight { get; set; }

		public ulong AnimRun { get; set; }

		public ulong AnimRunTwistLeft { get; set; }

		public ulong AnimRunTwistRight { get; set; }

		public float SyncFrameIdle { get; set; }

		public float SyncFrameIdleTwistLeft { get; set; }

		public float SyncFrameIdleTwistRight { get; set; }

		public float SyncFrameWalk { get; set; }

		public float SyncFrameWalkTwistLeft { get; set; }

		public float SyncFrameWalkTwistRight { get; set; }

		public float SyncFrameRun { get; set; }

		public float SyncFrameRunTwistLeft { get; set; }

		public float SyncFrameRunTwistRight { get; set; }

		public ulong Partition { get; set; }

		public int Priority { get; set; }

		public float BlendInTime { get; set; }

		public float BlendOutTime { get; set; }

		public float RadiusMin { get; set; }

		public float RadiusMax { get; set; }

		public float OffsetMax { get; set; }

		public BranchReference Branch { get; set; } = new BranchReference();

		public int InterruptPriority { get; set; }

		public PropertyConditionGroup Conditions { get; set; } = new PropertyConditionGroup(PropertyHash.Conditions);

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(Acceleration, endianess);
			output.WriteValueF32(TurningVelocity, endianess);
			output.WriteValueF32(TwistRateOn, endianess);
			output.WriteValueF32(TwistRateOff, endianess);
			output.WriteValueF32(VelocityWalk, endianess);
			output.WriteValueF32(VelocityRun, endianess);
			output.WriteValueF32(SmoothSteeringAngle, endianess);
			output.WriteValueF32(Phase, endianess);
			output.WriteValueU64(Locomotion, endianess);
			output.WriteValueU64(AnimIdle, endianess);
			output.WriteValueU64(AnimIdleTwistLeft, endianess);
			output.WriteValueU64(AnimIdleTwistRight, endianess);
			output.WriteValueU64(AnimWalk, endianess);
			output.WriteValueU64(AnimWalkTwistLeft, endianess);
			output.WriteValueU64(AnimWalkTwistRight, endianess);
			output.WriteValueU64(AnimRun, endianess);
			output.WriteValueU64(AnimRunTwistLeft, endianess);
			output.WriteValueU64(AnimRunTwistRight, endianess);
			output.WriteValueF32(SyncFrameIdle, endianess);
			output.WriteValueF32(SyncFrameIdleTwistLeft, endianess);
			output.WriteValueF32(SyncFrameIdleTwistRight, endianess);
			output.WriteValueF32(SyncFrameWalk, endianess);
			output.WriteValueF32(SyncFrameWalkTwistLeft, endianess);
			output.WriteValueF32(SyncFrameWalkTwistRight, endianess);
			output.WriteValueF32(SyncFrameRun, endianess);
			output.WriteValueF32(SyncFrameRunTwistLeft, endianess);
			output.WriteValueF32(SyncFrameRunTwistRight, endianess);
			output.WriteValueU64(Partition, endianess);
			output.WriteValueS32(Priority, endianess);
			output.WriteValueF32(BlendInTime, endianess);
			output.WriteValueF32(BlendOutTime, endianess);
			output.WriteValueF32(RadiusMin, endianess);
			output.WriteValueF32(RadiusMax, endianess);
			output.WriteValueF32(OffsetMax, endianess);
			Branch.Serialize(output, endianess);
			output.WriteValueS32(InterruptPriority, endianess);
		}

		public override void SerializeProperties(PrototypeGame game, Stream output, Endian endianess)
		{
			BaseProperty.SerializeBaseProperty(PrototypeGame.P1, output, endianess, Conditions);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Acceleration = input.ReadValueF32(endianess);
			TurningVelocity = input.ReadValueF32(endianess);
			TwistRateOn = input.ReadValueF32(endianess);
			TwistRateOff = input.ReadValueF32(endianess);
			VelocityWalk = input.ReadValueF32(endianess);
			VelocityRun = input.ReadValueF32(endianess);
			SmoothSteeringAngle = input.ReadValueF32(endianess);
			Phase = input.ReadValueF32(endianess);
			Locomotion = input.ReadValueU64(endianess);
			AnimIdle = input.ReadValueU64(endianess);
			AnimIdleTwistLeft = input.ReadValueU64(endianess);
			AnimIdleTwistRight = input.ReadValueU64(endianess);
			AnimWalk = input.ReadValueU64(endianess);
			AnimWalkTwistLeft = input.ReadValueU64(endianess);
			AnimWalkTwistRight = input.ReadValueU64(endianess);
			AnimRun = input.ReadValueU64(endianess);
			AnimRunTwistLeft = input.ReadValueU64(endianess);
			AnimRunTwistRight = input.ReadValueU64(endianess);
			SyncFrameIdle = input.ReadValueF32(endianess);
			SyncFrameIdleTwistLeft = input.ReadValueF32(endianess);
			SyncFrameIdleTwistRight = input.ReadValueF32(endianess);
			SyncFrameWalk = input.ReadValueF32(endianess);
			SyncFrameWalkTwistLeft = input.ReadValueF32(endianess);
			SyncFrameWalkTwistRight = input.ReadValueF32(endianess);
			SyncFrameRun = input.ReadValueF32(endianess);
			SyncFrameRunTwistLeft = input.ReadValueF32(endianess);
			SyncFrameRunTwistRight = input.ReadValueF32(endianess);
			Partition = input.ReadValueU64(endianess);
			Priority = input.ReadValueS32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
			RadiusMin = input.ReadValueF32(endianess);
			RadiusMax = input.ReadValueF32(endianess);
			OffsetMax = input.ReadValueF32(endianess);
			Branch = new BranchReference(input, endianess);
			InterruptPriority = input.ReadValueS32(endianess);
		}

		public override void DeserializeProperties(PrototypeGame game, Stream input, Endian endianess)
		{
			Conditions = BaseProperty.DeserializeConditionProperty(PrototypeGame.P1, input, endianess, PropertyHash.Conditions);
		}
	}
}
