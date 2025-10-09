using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.VelocityAngular)]
	public class VelocityAngularCondition : P1Condition
	{
		public VelocityOriginType Type { get; set; }

		public DirectionType Direction { get; set; }

		public CompareOperator Compare { get; set; }

		public float AngularVelocity { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Type);
			BaseProperty.SerializePropertyEnum(output, endianess, Direction);
			BaseProperty.SerializePropertyEnum(output, endianess, Compare);
			output.WriteValueF32(AngularVelocity, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Type = BaseProperty.DeserializePropertyEnum<VelocityOriginType>(input, endianess);
			Direction = BaseProperty.DeserializePropertyEnum<DirectionType>(input, endianess);
			Compare = BaseProperty.DeserializePropertyEnum<CompareOperator>(input, endianess);
			AngularVelocity = input.ReadValueF32(endianess);
		}
	}
}
