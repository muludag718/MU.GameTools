using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.PowerRagdollByAnimation)]
	public class PowerRagdollByAnimationTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public ulong Animation { get; set; }

		public float Speed { get; set; }

		public float InitFrame { get; set; }

		public float StartFrame { get; set; }

		public float EndFrame { get; set; }

		public AnimationCyclic Cyclic { get; set; }

		public ulong ConstraintPropertiesName { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueU64(Animation, endianess);
			output.WriteValueF32(Speed, endianess);
			output.WriteValueF32(InitFrame, endianess);
			output.WriteValueF32(StartFrame, endianess);
			output.WriteValueF32(EndFrame, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Cyclic);
			output.WriteValueU64(ConstraintPropertiesName, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Animation = input.ReadValueU64(endianess);
			Speed = input.ReadValueF32(endianess);
			InitFrame = input.ReadValueF32(endianess);
			StartFrame = input.ReadValueF32(endianess);
			EndFrame = input.ReadValueF32(endianess);
			Cyclic = BaseProperty.DeserializePropertyEnum<AnimationCyclic>(input, endianess);
			ConstraintPropertiesName = input.ReadValueU64(endianess);
		}
	}
}
