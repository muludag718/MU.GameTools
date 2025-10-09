using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.Velocity)]
	public class VelocityCondition : P1Condition
	{
		public enum VelocityType : ulong
		{
			Locomotion = 16331038302739513351uL,
			Physics = 8685988000896976323uL
		}

		public VelocityType Type { get; set; }

		public DirectionType Direction { get; set; }

		public CompareOperator Compare { get; set; }

		public float Velocity { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Type);
			BaseProperty.SerializePropertyEnum(output, endianess, Direction);
			BaseProperty.SerializePropertyEnum(output, endianess, Compare);
			output.WriteValueF32(Velocity, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Type = BaseProperty.DeserializePropertyEnum<VelocityType>(input, endianess);
			Direction = BaseProperty.DeserializePropertyEnum<DirectionType>(input, endianess);
			Compare = BaseProperty.DeserializePropertyEnum<CompareOperator>(input, endianess);
			Velocity = input.ReadValueF32(endianess);
		}
	}
}
