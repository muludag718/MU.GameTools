using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.GrabSlotClassName)]
	public class GrabSlotClassNameCondition : P1Condition
	{
		public ulong GrabSlotHash { get; set; }

		public CompareOperator Compare { get; set; }

		public ulong ClassnameHash { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueU64(GrabSlotHash, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Compare);
			output.WriteValueU64(ClassnameHash, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			GrabSlotHash = input.ReadValueU64(endianess);
			Compare = BaseProperty.DeserializePropertyEnum<CompareOperator>(input, endianess);
			ClassnameHash = input.ReadValueU64(endianess);
		}
	}
}
