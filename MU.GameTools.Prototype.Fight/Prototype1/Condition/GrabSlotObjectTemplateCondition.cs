using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.GrabSlotObjectTemplate)]
	public class GrabSlotObjectTemplateCondition : P1Condition
	{
		public ulong GrabSlot { get; set; }

		public CompareOperator Compare { get; set; }

		public ulong ObjectTemplate { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueU64(GrabSlot, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Compare);
			output.WriteValueU64(ObjectTemplate, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			GrabSlot = input.ReadValueU64(endianess);
			Compare = BaseProperty.DeserializePropertyEnum<CompareOperator>(input, endianess);
			ObjectTemplate = input.ReadValueU64(endianess);
		}
	}
}
