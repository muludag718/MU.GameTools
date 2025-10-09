using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.ReactionHitAttackType)]
	public class ReactionHitAttackTypeCondition : P1Condition
	{
		public bool DoesMatch { get; set; }

		public AttackType AttackType { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueB32(DoesMatch, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, AttackType);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			DoesMatch = input.ReadValueB32(endianess);
			AttackType = BaseProperty.DeserializePropertyEnum<AttackType>(input, endianess);
		}
	}
}
