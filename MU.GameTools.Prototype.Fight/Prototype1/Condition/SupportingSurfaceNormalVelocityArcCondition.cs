using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.SupportingSurfaceNormalVelocityArc)]
	public class SupportingSurfaceNormalVelocityArcCondition : P1Condition
	{
		public VelocityOriginType VelocityType { get; set; }

		public CompareOperator Compare { get; set; }

		public float Arc { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, VelocityType);
			BaseProperty.SerializePropertyEnum(output, endianess, Compare);
			output.WriteValueF32(Arc, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			VelocityType = BaseProperty.DeserializePropertyEnum<VelocityOriginType>(input, endianess);
			Compare = BaseProperty.DeserializePropertyEnum<CompareOperator>(input, endianess);
			Arc = input.ReadValueF32(endianess);
		}
	}
}
