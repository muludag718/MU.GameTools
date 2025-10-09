using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.TurnInput)]
	public class TurnInputCondition : P1Condition
	{
		public enum PreviourDirectionType : ulong
		{
			FacingDirection = 6813351740423163961uL,
			PhysicalVelocityDirection = 9314445876697039051uL
		}

		public enum DirectionRangeType : ulong
		{
			InsideRange = 16608783493572752571uL,
			OutsideRange = 5936946687786899414uL
		}

		public PreviourDirectionType PreviousDirection { get; set; }

		public float MinAngle { get; set; }

		public float MaxAngle { get; set; }

		public DirectionRangeType RangeType { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, PreviousDirection);
			output.WriteValueF32(MinAngle, endianess);
			output.WriteValueF32(MaxAngle, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, RangeType);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			PreviousDirection = BaseProperty.DeserializePropertyEnum<PreviourDirectionType>(input, endianess);
			MinAngle = input.ReadValueF32(endianess);
			MaxAngle = input.ReadValueF32(endianess);
			RangeType = BaseProperty.DeserializePropertyEnum<DirectionRangeType>(input, endianess);
		}
	}
}
