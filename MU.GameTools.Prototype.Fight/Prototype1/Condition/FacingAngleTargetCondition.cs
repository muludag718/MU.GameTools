using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.FacingAngleTarget)]
	public class FacingAngleTargetCondition : P1Condition
	{
		public enum YawPitchType : ulong
		{
			Yaw = 520688520109uL,
			Pitch = 7985452587274801402uL
		}

		public YawPitchType Type { get; set; }

		public CompareOperator CompareTime { get; set; }

		public float Angle { get; set; }

		public bool Signed { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Type);
			BaseProperty.SerializePropertyEnum(output, endianess, CompareTime);
			output.WriteValueF32(Angle, endianess);
			output.WriteValueB32(Signed, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Type = BaseProperty.DeserializePropertyEnum<YawPitchType>(input, endianess);
			CompareTime = BaseProperty.DeserializePropertyEnum<CompareOperator>(input, endianess);
			Angle = input.ReadValueF32(endianess);
			Signed = input.ReadValueB32(endianess);
		}
	}
}
