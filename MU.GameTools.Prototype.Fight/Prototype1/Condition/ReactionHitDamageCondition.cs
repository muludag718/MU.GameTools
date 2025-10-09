using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.ReactionHitDamage)]
	public class ReactionHitDamageCondition : P1Condition
	{
		public enum ReationDamageType : ulong
		{
			DamageGiven = 8477540622776547364uL,
			DamageTaken = 7591924666722235046uL
		}

		public ReationDamageType Type { get; set; }

		public CompareOperator Compare { get; set; }

		public float Damage { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Type);
			BaseProperty.SerializePropertyEnum(output, endianess, Compare);
			output.WriteValueF32(Damage, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Type = BaseProperty.DeserializePropertyEnum<ReationDamageType>(input, endianess);
			Compare = BaseProperty.DeserializePropertyEnum<CompareOperator>(input, endianess);
			Damage = input.ReadValueF32(endianess);
		}
	}
}
