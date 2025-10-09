using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.Speed)]
	public class SpeedCondition : P1Condition
	{
		public CompareOperator Since { get; set; }

		public float Speed { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Since);
			output.WriteValueF32(Speed, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Since = BaseProperty.DeserializePropertyEnum<CompareOperator>(input, endianess);
			Speed = input.ReadValueF32(endianess);
		}
	}
}
