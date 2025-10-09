using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.Devastator)]
	public class DevastatorTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float Radius { get; set; }

		public int TargetCount { get; set; }

		public BranchReference TargetBranch { get; set; } = new BranchReference();

		public BranchReference RandomTargetBranch { get; set; } = new BranchReference();

		public int MinTargetCount { get; set; }

		public float RandomHeightArc { get; set; }

		public float RandomMinRadius { get; set; }

		public float MinHeightArcOnGround { get; set; }

		public int MinTargetCategory { get; set; }

		public int MinTargetPriority { get; set; }

		public float AttackTimeBeginStart { get; set; }

		public float AttackTimeBeginStop { get; set; }

		public bool AttackTimeBeginRandom { get; set; }

		public float AttackTimeDuration { get; set; }

		public float AttackDamage { get; set; }

		public float RandomDamage { get; set; }

		public float CameraMaxArc { get; set; }

		public int CameraMaxTargets { get; set; }

		public int CameraMinTargetCategory { get; set; }

		public int CameraMinTargetPriority { get; set; }

		public float CameraLookAtTargetArc { get; set; }

		public float CameraLookAtTargetTime { get; set; }

		public float CameraSwitchTargetTime { get; set; }

		public bool UseCharacterHeap { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(Radius, endianess);
			output.WriteValueS32(TargetCount, endianess);
			TargetBranch.Serialize(output, endianess);
			RandomTargetBranch.Serialize(output, endianess);
			output.WriteValueS32(MinTargetCount, endianess);
			output.WriteValueF32(RandomHeightArc, endianess);
			output.WriteValueF32(RandomMinRadius, endianess);
			output.WriteValueF32(MinHeightArcOnGround, endianess);
			output.WriteValueS32(MinTargetCategory, endianess);
			output.WriteValueS32(MinTargetPriority, endianess);
			output.WriteValueF32(AttackTimeBeginStart, endianess);
			output.WriteValueF32(AttackTimeBeginStop, endianess);
			output.WriteValueB32(AttackTimeBeginRandom, endianess);
			output.WriteValueF32(AttackTimeDuration, endianess);
			output.WriteValueF32(AttackDamage, endianess);
			output.WriteValueF32(RandomDamage, endianess);
			output.WriteValueF32(CameraMaxArc, endianess);
			output.WriteValueS32(CameraMaxTargets, endianess);
			output.WriteValueS32(CameraMinTargetCategory, endianess);
			output.WriteValueS32(CameraMinTargetPriority, endianess);
			output.WriteValueF32(CameraLookAtTargetArc, endianess);
			output.WriteValueF32(CameraLookAtTargetTime, endianess);
			output.WriteValueF32(CameraSwitchTargetTime, endianess);
			output.WriteValueB32(UseCharacterHeap, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Radius = input.ReadValueF32(endianess);
			TargetCount = input.ReadValueS32(endianess);
			TargetBranch = new BranchReference(input, endianess);
			RandomTargetBranch = new BranchReference(input, endianess);
			MinTargetCount = input.ReadValueS32(endianess);
			RandomHeightArc = input.ReadValueF32(endianess);
			RandomMinRadius = input.ReadValueF32(endianess);
			MinHeightArcOnGround = input.ReadValueF32(endianess);
			MinTargetCategory = input.ReadValueS32(endianess);
			MinTargetPriority = input.ReadValueS32(endianess);
			AttackTimeBeginStart = input.ReadValueF32(endianess);
			AttackTimeBeginStop = input.ReadValueF32(endianess);
			AttackTimeBeginRandom = input.ReadValueB32(endianess);
			AttackTimeDuration = input.ReadValueF32(endianess);
			AttackDamage = input.ReadValueF32(endianess);
			RandomDamage = input.ReadValueF32(endianess);
			CameraMaxArc = input.ReadValueF32(endianess);
			CameraMaxTargets = input.ReadValueS32(endianess);
			CameraMinTargetCategory = input.ReadValueS32(endianess);
			CameraMinTargetPriority = input.ReadValueS32(endianess);
			CameraLookAtTargetArc = input.ReadValueF32(endianess);
			CameraLookAtTargetTime = input.ReadValueF32(endianess);
			CameraSwitchTargetTime = input.ReadValueF32(endianess);
			UseCharacterHeap = input.ReadValueB32(endianess);
		}
	}
}
