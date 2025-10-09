using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.HasCombatBudgetToken)]
	public class HasCombatBudgetTokenCondition : P1Condition
	{
		public enum CombatEnumType : ulong
		{
			Bullet = 1071813355822642564uL,
			Rocket = 14395127206582377560uL,
			Explosion = 6119690315119812053uL,
			Gib = 305522356882uL
		}

		public bool RequestInAdvance { get; set; }

		public CombatEnumType CombatType { get; set; }

		public bool HasToken { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueB32(RequestInAdvance, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, CombatType);
			output.WriteValueB32(HasToken, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			RequestInAdvance = input.ReadValueB32(endianess);
			CombatType = BaseProperty.DeserializePropertyEnum<CombatEnumType>(input, endianess);
			HasToken = input.ReadValueB32(endianess);
		}
	}
}
