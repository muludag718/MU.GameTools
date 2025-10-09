using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.FootstepDamage)]
	public class FootstepDamageTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float Phase { get; set; }

		public ulong JointName { get; set; }

		public Vector JointOffset { get; set; } = new Vector();

		public DamageType DamageType { get; set; }

		public AttackType AttackType { get; set; }

		public ulong HitType { get; set; }

		public ulong EffectType { get; set; }

		public float ScaleX { get; set; }

		public float ScaleY { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(Phase, endianess);
			output.WriteValueU64(JointName, endianess);
			JointOffset.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, DamageType);
			BaseProperty.SerializePropertyEnum(output, endianess, AttackType);
			output.WriteValueU64(HitType, endianess);
			output.WriteValueU64(EffectType, endianess);
			output.WriteValueF32(ScaleX, endianess);
			output.WriteValueF32(ScaleY, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Phase = input.ReadValueF32(endianess);
			JointName = input.ReadValueU64(endianess);
			JointOffset = new Vector(input, endianess);
			DamageType = BaseProperty.DeserializePropertyEnum<DamageType>(input, endianess);
			AttackType = BaseProperty.DeserializePropertyEnum<AttackType>(input, endianess);
			HitType = input.ReadValueU64(endianess);
			EffectType = input.ReadValueU64(endianess);
			ScaleX = input.ReadValueF32(endianess);
			ScaleY = input.ReadValueF32(endianess);
		}
	}
}
