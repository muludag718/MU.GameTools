using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Scenario)]
	[KnownCondition(ConditionHash.IsPlayerCharacter)]
	public class IsPlayerCharacterCondition : P1Condition
	{
		public ScenarioGameObjectSlot Affiliate { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Affiliate);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Affiliate = BaseProperty.DeserializePropertyEnum<ScenarioGameObjectSlot>(input, endianess);
		}
	}
}
