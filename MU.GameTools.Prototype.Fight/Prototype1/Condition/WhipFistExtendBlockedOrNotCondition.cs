using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.WhipFistExtendBlockedOrNot)]
	public class WhipFistExtendBlockedOrNotCondition : P1Condition
	{
		public bool Blocked { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueB32(Blocked, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Blocked = input.ReadValueB32(endianess);
		}
	}
}
