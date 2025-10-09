using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Scenario)]
	[KnownCondition(ConditionHash.CurrentState)]
	public class CurrentStateCondition : P1Condition
	{
		public BranchReference StateRef { get; set; } = new BranchReference();

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			StateRef.Serialize(output, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			StateRef = new BranchReference(input, endianess);
		}
	}
}
