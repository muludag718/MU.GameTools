using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.DestinationTargetOrientation)]
	public class DestinationTargetOrientationCondition : P1Condition
	{
		public CompareOperator CompareTime { get; set; }

		public float Angle { get; set; }

		public bool Signed { get; set; }

		public bool UseParams { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, CompareTime);
			output.WriteValueF32(Angle, endianess);
			output.WriteValueB32(Signed, endianess);
			output.WriteValueB32(UseParams, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			CompareTime = BaseProperty.DeserializePropertyEnum<CompareOperator>(input, endianess);
			Angle = input.ReadValueF32(endianess);
			Signed = input.ReadValueB32(endianess);
			UseParams = input.ReadValueB32(endianess);
		}
	}
}
