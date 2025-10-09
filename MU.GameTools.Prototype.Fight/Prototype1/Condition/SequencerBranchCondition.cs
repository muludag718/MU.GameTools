using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.SequencerBranch)]
	public class SequencerBranchCondition : P1Condition
	{
		public CompareOperator Compare { get; set; }

		public BranchReference Branch { get; set; } = new BranchReference();

		public bool Recurse { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Compare);
			Branch.Serialize(output, endianess);
			output.WriteValueB32(Recurse, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Compare = BaseProperty.DeserializePropertyEnum<CompareOperator>(input, endianess);
			Branch = new BranchReference(input, endianess);
			Recurse = input.ReadValueB32(endianess);
		}
	}
}
