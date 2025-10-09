using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.GrabSlot)]
	public class GrabSlotCondition : P1Condition
	{
		public ulong GrabSlotHash { get; set; }

		public bool IsGrabbing { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueU64(GrabSlotHash, endianess);
			output.WriteValueB32(IsGrabbing);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			GrabSlotHash = input.ReadValueU64(endianess);
			IsGrabbing = input.ReadValueB32(endianess);
		}
	}
}
