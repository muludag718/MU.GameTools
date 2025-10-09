using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Scenario)]
	[KnownCondition(ConditionHash.HasTag)]
	public class HasTagCondition : P1Condition
	{
		public ScenarioGameObjectSlot Affiliate { get; set; }

		public string Tag { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Affiliate);
			output.WriteStringAlignedU32(Tag, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Affiliate = BaseProperty.DeserializePropertyEnum<ScenarioGameObjectSlot>(input, endianess);
			Tag = input.ReadStringAlignedU32(endianess);
		}
	}
}
