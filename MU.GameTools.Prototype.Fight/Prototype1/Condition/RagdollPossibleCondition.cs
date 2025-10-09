using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.RagdollPossible)]
	public class RagdollPossibleCondition : P1Condition
	{
		public bool RagdollAlreadyCreated { get; set; }

		public bool Possible { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueB32(RagdollAlreadyCreated, endianess);
			output.WriteValueB32(Possible, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			RagdollAlreadyCreated = input.ReadValueB32(endianess);
			Possible = input.ReadValueB32(endianess);
		}
	}
}
