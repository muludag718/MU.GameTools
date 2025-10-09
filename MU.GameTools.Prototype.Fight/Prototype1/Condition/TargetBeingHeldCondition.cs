using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.TargetBeingHeld)]
	public class TargetBeingHeldCondition : P1Condition
	{
		public bool Held { get; set; }

		public bool DontCountIfHeldByMe { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueB32(Held, endianess);
			output.WriteValueB32(DontCountIfHeldByMe, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Held = input.ReadValueB32(endianess);
			DontCountIfHeldByMe = input.ReadValueB32(endianess);
		}
	}
}
