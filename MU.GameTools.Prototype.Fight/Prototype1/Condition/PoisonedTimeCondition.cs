using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.PoisonedTime)]
	public class PoisonedTimeCondition : P1Condition
	{
		public CompareOperator CompareTime { get; set; }

		public float Time { get; set; }

		public int PoisonType { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, CompareTime);
			output.WriteValueF32(Time, endianess);
			output.WriteValueS32(PoisonType, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			CompareTime = BaseProperty.DeserializePropertyEnum<CompareOperator>(input, endianess);
			Time = input.ReadValueF32(endianess);
			PoisonType = input.ReadValueS32(endianess);
		}
	}
}
