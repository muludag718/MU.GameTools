using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.TargetDefense)]
	public class TargetDefenseCondition : P1Condition
	{
		public enum DefenseType : ulong
		{
			Armor = 4585032012356833025uL,
			Block = 4693892474936023823uL
		}

		public DefenseType Defense { get; set; }

		public CompareOperator Compare { get; set; }

		public float Value { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Defense);
			BaseProperty.SerializePropertyEnum(output, endianess, Compare);
			output.WriteValueF32(Value, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Defense = BaseProperty.DeserializePropertyEnum<DefenseType>(input, endianess);
			Compare = BaseProperty.DeserializePropertyEnum<CompareOperator>(input, endianess);
			Value = input.ReadValueF32(endianess);
		}
	}
}
