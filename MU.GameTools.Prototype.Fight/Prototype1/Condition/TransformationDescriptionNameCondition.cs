using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Scenario)]
	[KnownCondition(ConditionHash.TransformationDescriptionName)]
	public class TransformationDescriptionNameCondition : P1Condition
	{
		public ScenarioGameObjectSlot Affiliate { get; set; }

		public ulong Name { get; set; }

		public bool IsActive { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Affiliate);
			output.WriteValueU64(Name, endianess);
			output.WriteValueB32(IsActive, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Affiliate = BaseProperty.DeserializePropertyEnum<ScenarioGameObjectSlot>(input, endianess);
			Name = input.ReadValueU64(endianess);
			IsActive = input.ReadValueB32(endianess);
		}
	}
}
