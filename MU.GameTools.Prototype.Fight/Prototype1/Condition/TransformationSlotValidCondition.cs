using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.TransformationSlotValid)]
	public class TransformationSlotValidCondition : P1Condition
	{
		public ulong SlotName { get; set; }

		public bool IsValid { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueU64(SlotName, endianess);
			output.WriteValueB32(IsValid, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			SlotName = input.ReadValueU64(endianess);
			IsValid = input.ReadValueB32(endianess);
		}
	}
}
