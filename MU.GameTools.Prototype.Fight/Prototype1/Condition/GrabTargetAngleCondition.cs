using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.GrabTargetAngle)]
	public class GrabTargetAngleCondition : P1Condition
	{
		public CompareOperator Compare { get; set; }

		public float Angle { get; set; }

		public bool UseMovementDirection { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Compare);
			output.WriteValueF32(Angle, endianess);
			output.WriteValueB32(UseMovementDirection, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Compare = BaseProperty.DeserializePropertyEnum<CompareOperator>(input, endianess);
			Angle = input.ReadValueF32(endianess);
			UseMovementDirection = input.ReadValueB32(endianess);
		}
	}
}
