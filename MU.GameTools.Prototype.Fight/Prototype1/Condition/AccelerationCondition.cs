using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.Acceleration)]
	public class AccelerationCondition : P1Condition
	{
		public VelocityOriginType Type { get; set; }

		public DirectionType Direction { get; set; }

		public CompareOperator Compare { get; set; }

		public float Acceleration { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Type);
			BaseProperty.SerializePropertyEnum(output, endianess, Direction);
			BaseProperty.SerializePropertyEnum(output, endianess, Compare);
			output.WriteValueF32(Acceleration, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Type = BaseProperty.DeserializePropertyEnum<VelocityOriginType>(input, endianess);
			Direction = BaseProperty.DeserializePropertyEnum<DirectionType>(input, endianess);
			Compare = BaseProperty.DeserializePropertyEnum<CompareOperator>(input, endianess);
			Acceleration = input.ReadValueF32(endianess);
		}
	}
}
