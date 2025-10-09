using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.DistanceToJoint)]
	public class DistanceToJointCondition : P1Condition
	{
		public ulong Joint { get; set; }

		public ulong GrabSlot { get; set; }

		public CompareOperator Compare { get; set; }

		public float Distance { get; set; }

		public Vector Offset { get; set; } = new Vector();

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueU64(Joint, endianess);
			output.WriteValueU64(GrabSlot, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Compare);
			output.WriteValueF32(Distance, endianess);
			Offset.Serialize(output, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Joint = input.ReadValueU64(endianess);
			GrabSlot = input.ReadValueU64(endianess);
			Compare = BaseProperty.DeserializePropertyEnum<CompareOperator>(input, endianess);
			Distance = input.ReadValueF32(endianess);
			Offset = new Vector(input, endianess);
		}
	}
}
