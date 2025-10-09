using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.SurfaceAngle)]
	public class SurfaceAngleCondition : P1Condition
	{
		public CompareOperator Compare { get; set; }

		public Vector Direction { get; set; } = new Vector();

		public float Tolerance { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Compare);
			Direction.Serialize(output, endianess);
			output.WriteValueF32(Tolerance, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Compare = BaseProperty.DeserializePropertyEnum<CompareOperator>(input, endianess);
			Direction.Deserialize(input, endianess);
			Tolerance = input.ReadValueF32(endianess);
		}
	}
}
