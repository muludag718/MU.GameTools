using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.ReactionHitDamageType)]
	public class ReactionHitDamageTypeCondition : P1Condition
	{
		public bool DoesMatch { get; set; }

		public DamageType DamageType { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueB32(DoesMatch, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, DamageType);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			DoesMatch = input.ReadValueB32(endianess);
			DamageType = BaseProperty.DeserializePropertyEnum<DamageType>(input, endianess);
		}
	}
}
