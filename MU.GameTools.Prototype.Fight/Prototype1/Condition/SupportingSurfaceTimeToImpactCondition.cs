using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.SupportingSurfaceTimeToImpact)]
	public class SupportingSurfaceTimeToImpactCondition : P1Condition
	{
		public VelocityOriginType VelocityType { get; set; }

		public CompareOperator Compare { get; set; }

		public float TimeToImpact { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, VelocityType);
			BaseProperty.SerializePropertyEnum(output, endianess, Compare);
			output.WriteValueF32(TimeToImpact, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			VelocityType = BaseProperty.DeserializePropertyEnum<VelocityOriginType>(input, endianess);
			Compare = BaseProperty.DeserializePropertyEnum<CompareOperator>(input, endianess);
			TimeToImpact = input.ReadValueF32(endianess);
		}
	}
}
