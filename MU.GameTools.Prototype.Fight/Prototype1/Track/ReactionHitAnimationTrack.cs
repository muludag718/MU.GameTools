using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.ReactionHitAnimation)]
	public class ReactionHitAnimationTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeScale { get; set; }

		public float TimeEndMin { get; set; }

		public ulong Animation { get; set; }

		public float Speed { get; set; }

		public float SpeedMax { get; set; }

		public float InitFrame { get; set; }

		public float RandomFrame { get; set; }

		public float StartFrame { get; set; }

		public float EndFrame { get; set; }

		public AnimationCyclic Cyclic { get; set; }

		public ulong Partition { get; set; }

		public int Priority { get; set; }

		public float BlendInTime { get; set; }

		public float BlendOutTime { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeScale, endianess);
			output.WriteValueF32(TimeEndMin, endianess);
			output.WriteValueU64(Animation, endianess);
			output.WriteValueF32(Speed, endianess);
			output.WriteValueF32(SpeedMax, endianess);
			output.WriteValueF32(InitFrame, endianess);
			output.WriteValueF32(RandomFrame, endianess);
			output.WriteValueF32(StartFrame, endianess);
			output.WriteValueF32(EndFrame, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Cyclic);
			output.WriteValueU64(Partition, endianess);
			output.WriteValueS32(Priority, endianess);
			output.WriteValueF32(BlendInTime, endianess);
			output.WriteValueF32(BlendOutTime, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeScale = input.ReadValueF32(endianess);
			TimeEndMin = input.ReadValueF32(endianess);
			Animation = input.ReadValueU64(endianess);
			Speed = input.ReadValueF32(endianess);
			SpeedMax = input.ReadValueF32(endianess);
			InitFrame = input.ReadValueF32(endianess);
			RandomFrame = input.ReadValueF32(endianess);
			StartFrame = input.ReadValueF32(endianess);
			EndFrame = input.ReadValueF32(endianess);
			Cyclic = BaseProperty.DeserializePropertyEnum<AnimationCyclic>(input, endianess);
			Partition = input.ReadValueU64(endianess);
			Priority = input.ReadValueS32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
		}
	}
}
