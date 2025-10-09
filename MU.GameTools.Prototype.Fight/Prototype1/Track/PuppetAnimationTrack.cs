using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.PuppetAnimation)]
	public class PuppetAnimationTrack : P1Track
	{
		public enum AnimationSyncPhase : ulong
		{
			Legacy = 3349652082457766725uL,
			FromPuppetPhase = 15638706115388059527uL
		}

		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public ulong Animation { get; set; }

		public float Speed { get; set; }

		public float RandomSpeedVariation { get; set; }

		public float InitFrame { get; set; }

		public float StartFrame { get; set; }

		public float EndFrame { get; set; }

		public AnimationCyclic Cyclic { get; set; }

		public bool SyncFrame { get; set; }

		public bool PhaseMatch { get; set; }

		public bool ReuseExistingDriver { get; set; }

		public AnimationSyncPhase SyncPhase { get; set; }

		public float SyncPhaseMinFrame { get; set; }

		public float SyncPhaseMaxFrame { get; set; }

		public bool HasRootTranslation { get; set; }

		public bool HasRootRotation { get; set; }

		public ulong Partition { get; set; }

		public float Weight { get; set; }

		public int Priority { get; set; }

		public float BlendInTime { get; set; }

		public float BlendOutTime { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueU64(Animation, endianess);
			output.WriteValueF32(Speed, endianess);
			output.WriteValueF32(RandomSpeedVariation, endianess);
			output.WriteValueF32(InitFrame, endianess);
			output.WriteValueF32(StartFrame, endianess);
			output.WriteValueF32(EndFrame, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Cyclic);
			output.WriteValueB32(SyncFrame, endianess);
			output.WriteValueB32(PhaseMatch, endianess);
			output.WriteValueB32(ReuseExistingDriver, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, SyncPhase);
			output.WriteValueF32(SyncPhaseMinFrame, endianess);
			output.WriteValueF32(SyncPhaseMaxFrame, endianess);
			output.WriteValueB32(HasRootTranslation, endianess);
			output.WriteValueB32(HasRootRotation, endianess);
			output.WriteValueU64(Partition, endianess);
			output.WriteValueF32(Weight, endianess);
			output.WriteValueS32(Priority, endianess);
			output.WriteValueF32(BlendInTime, endianess);
			output.WriteValueF32(BlendOutTime, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Animation = input.ReadValueU64(endianess);
			Speed = input.ReadValueF32(endianess);
			RandomSpeedVariation = input.ReadValueF32(endianess);
			InitFrame = input.ReadValueF32(endianess);
			StartFrame = input.ReadValueF32(endianess);
			EndFrame = input.ReadValueF32(endianess);
			Cyclic = BaseProperty.DeserializePropertyEnum<AnimationCyclic>(input, endianess);
			SyncFrame = input.ReadValueB32(endianess);
			PhaseMatch = input.ReadValueB32(endianess);
			ReuseExistingDriver = input.ReadValueB32(endianess);
			SyncPhase = BaseProperty.DeserializePropertyEnum<AnimationSyncPhase>(input, endianess);
			SyncPhaseMinFrame = input.ReadValueF32(endianess);
			SyncPhaseMaxFrame = input.ReadValueF32(endianess);
			HasRootTranslation = input.ReadValueB32(endianess);
			HasRootRotation = input.ReadValueB32(endianess);
			Partition = input.ReadValueU64(endianess);
			Weight = input.ReadValueF32(endianess);
			Priority = input.ReadValueS32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
		}
	}
}
