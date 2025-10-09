using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.LocoInput)]
	public class LocoInputCondition : P1Condition
	{
		public enum InputMotionType : ulong
		{
			LinearMotion = 4848880419476874243uL,
			Steering = 16854725670608644405uL
		}

		public InputMotionType InputType { get; set; }

		public CompareOperator CompareTime { get; set; }

		public float Time { get; set; }

		public CompareOperator CompareValue { get; set; }

		public float Value { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, InputType);
			BaseProperty.SerializePropertyEnum(output, endianess, CompareTime);
			output.WriteValueF32(Time, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, CompareValue);
			output.WriteValueF32(Value, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			InputType = BaseProperty.DeserializePropertyEnum<InputMotionType>(input, endianess);
			CompareTime = BaseProperty.DeserializePropertyEnum<CompareOperator>(input, endianess);
			Time = input.ReadValueF32(endianess);
			CompareValue = BaseProperty.DeserializePropertyEnum<CompareOperator>(input, endianess);
			Value = input.ReadValueF32(endianess);
		}
	}
}
