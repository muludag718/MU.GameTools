using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.AnimationBlendDirectional)]
	public class AnimationBlendDirectionalTrack : P1Track
	{
		public enum InputAxisType : ulong
		{
			MovementAxis = 1365744333596055274uL
		}

		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public InputAxisType Input { get; set; }

		public float BlendRate { get; set; }

		public float Speed { get; set; }

		public AnimationCyclic Cyclic { get; set; }

		public ulong AnimNeutral { get; set; }

		public float AnimNeutralSyncFrame { get; set; }

		public float AnimNeutralStartFrame { get; set; }

		public float AnimNeutralEndFrame { get; set; }

		public float AnimNeutralSpeed { get; set; }

		public ulong AnimNorth { get; set; }

		public float AnimNorthSyncFrame { get; set; }

		public float AnimNorthStartFrame { get; set; }

		public float AnimNorthEndFrame { get; set; }

		public float AnimNorthSpeed { get; set; }

		public AnimationAllowedTransitionsType AnimNorthAllowedTransitions { get; set; }

		public ulong AnimEast { get; set; }

		public float AnimEastSyncFrame { get; set; }

		public float AnimEastStartFrame { get; set; }

		public float AnimEastEndFrame { get; set; }

		public float AnimEastSpeed { get; set; }

		public AnimationAllowedTransitionsType AnimEastAllowedTransitions { get; set; }

		public ulong AnimSouth { get; set; }

		public float AnimSouthSyncFrame { get; set; }

		public float AnimSouthStartFrame { get; set; }

		public float AnimSouthEndFrame { get; set; }

		public float AnimSouthSpeed { get; set; }

		public AnimationAllowedTransitionsType AnimSouthAllowedTransitions { get; set; }

		public ulong AnimWest { get; set; }

		public float AnimWestSyncFrame { get; set; }

		public float AnimWestStartFrame { get; set; }

		public float AnimWestEndFrame { get; set; }

		public float AnimWestSpeed { get; set; }

		public AnimationAllowedTransitionsType AnimWestAllowedTransitions { get; set; }

		public ulong Partition { get; set; }

		public int Priority { get; set; }

		public float BlendInTime { get; set; }

		public float BlendOutTime { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Input);
			output.WriteValueF32(BlendRate, endianess);
			output.WriteValueF32(Speed, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Cyclic);
			output.WriteValueU64(AnimNeutral, endianess);
			output.WriteValueF32(AnimNeutralSyncFrame, endianess);
			output.WriteValueF32(AnimNeutralStartFrame, endianess);
			output.WriteValueF32(AnimNeutralEndFrame, endianess);
			output.WriteValueF32(AnimNeutralSpeed, endianess);
			output.WriteValueU64(AnimNorth, endianess);
			output.WriteValueF32(AnimNorthSyncFrame, endianess);
			output.WriteValueF32(AnimNorthStartFrame, endianess);
			output.WriteValueF32(AnimNorthEndFrame, endianess);
			output.WriteValueF32(AnimNorthSpeed, endianess);
			BaseProperty.SerializePropertyBitfield(output, endianess, AnimNorthAllowedTransitions);
			output.WriteValueU64(AnimEast, endianess);
			output.WriteValueF32(AnimEastSyncFrame, endianess);
			output.WriteValueF32(AnimEastStartFrame, endianess);
			output.WriteValueF32(AnimEastEndFrame, endianess);
			output.WriteValueF32(AnimEastSpeed, endianess);
			BaseProperty.SerializePropertyBitfield(output, endianess, AnimEastAllowedTransitions);
			output.WriteValueU64(AnimSouth, endianess);
			output.WriteValueF32(AnimSouthSyncFrame, endianess);
			output.WriteValueF32(AnimSouthStartFrame, endianess);
			output.WriteValueF32(AnimSouthEndFrame, endianess);
			output.WriteValueF32(AnimSouthSpeed, endianess);
			BaseProperty.SerializePropertyBitfield(output, endianess, AnimSouthAllowedTransitions);
			output.WriteValueU64(AnimWest, endianess);
			output.WriteValueF32(AnimWestSyncFrame, endianess);
			output.WriteValueF32(AnimWestStartFrame, endianess);
			output.WriteValueF32(AnimWestEndFrame, endianess);
			output.WriteValueF32(AnimWestSpeed, endianess);
			BaseProperty.SerializePropertyBitfield(output, endianess, AnimWestAllowedTransitions);
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
			Input = BaseProperty.DeserializePropertyEnum<InputAxisType>(input, endianess);
			BlendRate = input.ReadValueF32(endianess);
			Speed = input.ReadValueF32(endianess);
			Cyclic = BaseProperty.DeserializePropertyEnum<AnimationCyclic>(input, endianess);
			AnimNeutral = input.ReadValueU64(endianess);
			AnimNeutralSyncFrame = input.ReadValueF32(endianess);
			AnimNeutralStartFrame = input.ReadValueF32(endianess);
			AnimNeutralEndFrame = input.ReadValueF32(endianess);
			AnimNeutralSpeed = input.ReadValueF32(endianess);
			AnimNorth = input.ReadValueU64(endianess);
			AnimNorthSyncFrame = input.ReadValueF32(endianess);
			AnimNorthStartFrame = input.ReadValueF32(endianess);
			AnimNorthEndFrame = input.ReadValueF32(endianess);
			AnimNorthSpeed = input.ReadValueF32(endianess);
			AnimNorthAllowedTransitions = BaseProperty.DeserializePropertyBitfield<AnimationAllowedTransitionsType>(input, endianess);
			AnimEast = input.ReadValueU64(endianess);
			AnimEastSyncFrame = input.ReadValueF32(endianess);
			AnimEastStartFrame = input.ReadValueF32(endianess);
			AnimEastEndFrame = input.ReadValueF32(endianess);
			AnimEastSpeed = input.ReadValueF32(endianess);
			AnimEastAllowedTransitions = BaseProperty.DeserializePropertyBitfield<AnimationAllowedTransitionsType>(input, endianess);
			AnimSouth = input.ReadValueU64(endianess);
			AnimSouthSyncFrame = input.ReadValueF32(endianess);
			AnimSouthStartFrame = input.ReadValueF32(endianess);
			AnimSouthEndFrame = input.ReadValueF32(endianess);
			AnimSouthSpeed = input.ReadValueF32(endianess);
			AnimSouthAllowedTransitions = BaseProperty.DeserializePropertyBitfield<AnimationAllowedTransitionsType>(input, endianess);
			AnimWest = input.ReadValueU64(endianess);
			AnimWestSyncFrame = input.ReadValueF32(endianess);
			AnimWestStartFrame = input.ReadValueF32(endianess);
			AnimWestEndFrame = input.ReadValueF32(endianess);
			AnimWestSpeed = input.ReadValueF32(endianess);
			AnimWestAllowedTransitions = BaseProperty.DeserializePropertyBitfield<AnimationAllowedTransitionsType>(input, endianess);
			Partition = input.ReadValueU64(endianess);
			Priority = input.ReadValueS32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
		}
	}
}
