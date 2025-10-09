using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.TransformationSlotTransformDesired)]
	public class TransformationSlotTransformDesiredCondition : P1Condition
	{
		public ulong SlotName { get; set; }

		public bool TransformDesired { get; set; }

		public bool Loaded { get; set; }

		public bool Loading { get; set; }

		public bool MatchName { get; set; }

		public ulong DesiredName { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueU64(SlotName, endianess);
			output.WriteValueB32(TransformDesired, endianess);
			output.WriteValueB32(Loaded, endianess);
			output.WriteValueB32(Loading, endianess);
			output.WriteValueB32(MatchName, endianess);
			output.WriteValueU64(DesiredName, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			SlotName = input.ReadValueU64(endianess);
			TransformDesired = input.ReadValueB32(endianess);
			Loaded = input.ReadValueB32(endianess);
			Loading = input.ReadValueB32(endianess);
			MatchName = input.ReadValueB32(endianess);
			DesiredName = input.ReadValueU64(endianess);
		}
	}
}
