using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.TargetAngle)]
	public class TargetAngleCondition : P1Condition
	{
		public CompareOperator CompareTime { get; set; }

		public float Angle { get; set; }

		public float Arc { get; set; }

		public bool UseMovementDirection { get; set; }

		public bool UseInputDirection { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, CompareTime);
			output.WriteValueF32(Angle, endianess);
			output.WriteValueF32(Arc, endianess);
			output.WriteValueB32(UseMovementDirection, endianess);
			output.WriteValueB32(UseInputDirection, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			CompareTime = BaseProperty.DeserializePropertyEnum<CompareOperator>(input, endianess);
			Angle = input.ReadValueF32(endianess);
			Arc = input.ReadValueF32(endianess);
			UseMovementDirection = input.ReadValueB32(endianess);
			UseInputDirection = input.ReadValueB32(endianess);
		}
	}
}
