using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.AnimationBlendSimple)]
	public class AnimationBlendSimpleTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public ulong WeightVariable { get; set; }

		public float Speed { get; set; }

		public AnimationCyclic Cyclic { get; set; }

		public ulong AnimA { get; set; }

		public float AnimASyncFrame { get; set; }

		public float AnimAStartFrame { get; set; }

		public float AnimAEndFrame { get; set; }

		public float AnimASpeed { get; set; }

		public ulong AnimB { get; set; }

		public float AnimBSyncFrame { get; set; }

		public float AnimBStartFrame { get; set; }

		public float AnimBEndFrame { get; set; }

		public float AnimBSpeed { get; set; }

		public ulong Partition { get; set; }

		public int Priority { get; set; }

		public float BlendInTime { get; set; }

		public float BlendOutTime { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueU64(WeightVariable, endianess);
			output.WriteValueF32(Speed, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Cyclic);
			output.WriteValueU64(AnimA, endianess);
			output.WriteValueF32(AnimASyncFrame, endianess);
			output.WriteValueF32(AnimAStartFrame, endianess);
			output.WriteValueF32(AnimAEndFrame, endianess);
			output.WriteValueF32(AnimASpeed, endianess);
			output.WriteValueU64(AnimB, endianess);
			output.WriteValueF32(AnimBSyncFrame, endianess);
			output.WriteValueF32(AnimBStartFrame, endianess);
			output.WriteValueF32(AnimBEndFrame, endianess);
			output.WriteValueF32(AnimBSpeed, endianess);
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
			WeightVariable = input.ReadValueU64(endianess);
			Speed = input.ReadValueF32(endianess);
			Cyclic = BaseProperty.DeserializePropertyEnum<AnimationCyclic>(input, endianess);
			AnimA = input.ReadValueU64(endianess);
			AnimASyncFrame = input.ReadValueF32(endianess);
			AnimAStartFrame = input.ReadValueF32(endianess);
			AnimAEndFrame = input.ReadValueF32(endianess);
			AnimASpeed = input.ReadValueF32(endianess);
			AnimB = input.ReadValueU64(endianess);
			AnimBSyncFrame = input.ReadValueF32(endianess);
			AnimBStartFrame = input.ReadValueF32(endianess);
			AnimBEndFrame = input.ReadValueF32(endianess);
			AnimBSpeed = input.ReadValueF32(endianess);
			Partition = input.ReadValueU64(endianess);
			Priority = input.ReadValueS32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
		}
	}
}
