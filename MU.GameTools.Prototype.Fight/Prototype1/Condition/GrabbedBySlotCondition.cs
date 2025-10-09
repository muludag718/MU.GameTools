using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.GrabbedBySlot)]
	public class GrabbedBySlotCondition : P1Condition
	{
		public bool IsGrabbed { get; set; }

		public ulong GrabSlotHash { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueB32(IsGrabbed);
			output.WriteValueU64(GrabSlotHash, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			IsGrabbed = input.ReadValueB32(endianess);
			GrabSlotHash = input.ReadValueU64(endianess);
		}
	}
}
