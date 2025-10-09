using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.CheckEffectTimer)]
	public class CheckEffectTimerCondition : P1Condition
	{
		public ulong TimerName { get; set; }

		public CompareOperator Compare { get; set; }

		public float TimeElapsed { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueU64(TimerName, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Compare);
			output.WriteValueF32(TimeElapsed, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimerName = input.ReadValueU64(endianess);
			Compare = BaseProperty.DeserializePropertyEnum<CompareOperator>(input, endianess);
			TimeElapsed = input.ReadValueF32(endianess);
		}
	}
}
