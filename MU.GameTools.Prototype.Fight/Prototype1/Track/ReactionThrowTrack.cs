using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.ReactionThrow)]
	public class ReactionThrowTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float DamageMin { get; set; }

		public float DamageMax { get; set; }

		public Vector SpinAxisX { get; set; } = new Vector();

		public Vector SpinAxisY { get; set; } = new Vector();

		public float SelfDamageScale { get; set; }

		public bool UsePuppet { get; set; }

		public float OrientOffset { get; set; }

		public int Priority { get; set; }

		public float BlendInTime { get; set; }

		public float BlendOutTime { get; set; }

		public float PhysicalVelocityCheckDelay { get; set; }

		public float StopAtVelocityRatio { get; set; }

		public ulong ThreatName { get; set; }

		public float ThreatRadiusScale { get; set; }

		public float ThreatProjectedDist { get; set; }

		public BranchReference OnCollision { get; set; } = new BranchReference();

		public int CollisionInterruptPriority { get; set; }

		public float CollisionReactionDelay { get; set; }

		public int MaxHitEffects { get; set; }

		public TargetClass OverrideTargetClass { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(DamageMin, endianess);
			output.WriteValueF32(DamageMax, endianess);
			SpinAxisX.Serialize(output, endianess);
			SpinAxisY.Serialize(output, endianess);
			output.WriteValueF32(SelfDamageScale, endianess);
			output.WriteValueB32(UsePuppet, endianess);
			output.WriteValueF32(OrientOffset, endianess);
			output.WriteValueS32(Priority, endianess);
			output.WriteValueF32(BlendInTime, endianess);
			output.WriteValueF32(BlendOutTime, endianess);
			output.WriteValueF32(PhysicalVelocityCheckDelay, endianess);
			output.WriteValueF32(StopAtVelocityRatio, endianess);
			output.WriteValueU64(ThreatName, endianess);
			output.WriteValueF32(ThreatRadiusScale, endianess);
			output.WriteValueF32(ThreatProjectedDist, endianess);
			OnCollision.Serialize(output, endianess);
			output.WriteValueS32(CollisionInterruptPriority, endianess);
			output.WriteValueF32(CollisionReactionDelay, endianess);
			output.WriteValueS32(MaxHitEffects, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, OverrideTargetClass);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			DamageMin = input.ReadValueF32(endianess);
			DamageMax = input.ReadValueF32(endianess);
			SpinAxisX = new Vector(input, endianess);
			SpinAxisY = new Vector(input, endianess);
			SelfDamageScale = input.ReadValueF32(endianess);
			UsePuppet = input.ReadValueB32(endianess);
			OrientOffset = input.ReadValueF32(endianess);
			Priority = input.ReadValueS32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
			PhysicalVelocityCheckDelay = input.ReadValueF32(endianess);
			StopAtVelocityRatio = input.ReadValueF32(endianess);
			ThreatName = input.ReadValueU64(endianess);
			ThreatRadiusScale = input.ReadValueF32(endianess);
			ThreatProjectedDist = input.ReadValueF32(endianess);
			OnCollision = new BranchReference(input, endianess);
			CollisionInterruptPriority = input.ReadValueS32(endianess);
			CollisionReactionDelay = input.ReadValueF32(endianess);
			MaxHitEffects = input.ReadValueS32(endianess);
			OverrideTargetClass = BaseProperty.DeserializePropertyEnum<TargetClass>(input, endianess);
		}
	}
}
