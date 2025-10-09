using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.DevastatorTargetHit)]
	public class DevastatorTargetHitTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public bool UseAttackTimeBegin { get; set; }

		public bool UseAttackTimeEnd { get; set; }

		public float Damage { get; set; }

		public Vector Impulse { get; set; } = new Vector();

		public AttackType AttackType { get; set; }

		public DamageType DamageType { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueB32(UseAttackTimeBegin, endianess);
			output.WriteValueB32(UseAttackTimeEnd, endianess);
			output.WriteValueF32(Damage, endianess);
			Impulse.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, AttackType);
			BaseProperty.SerializePropertyEnum(output, endianess, DamageType);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			UseAttackTimeBegin = input.ReadValueB32(endianess);
			UseAttackTimeEnd = input.ReadValueB32(endianess);
			Damage = input.ReadValueF32(endianess);
			Impulse.Deserialize(input, endianess);
			AttackType = BaseProperty.DeserializePropertyEnum<AttackType>(input, endianess);
			DamageType = BaseProperty.DeserializePropertyEnum<DamageType>(input, endianess);
		}
	}
}
