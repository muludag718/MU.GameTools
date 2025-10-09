using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.OrientationNormalAngle)]
	public class OrientationNormalAngleCondition : P1Condition
	{
		public Vector Normal { get; set; } = new Vector();

		public CompareOperator Compare { get; set; }

		public float Angle { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			Normal.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Compare);
			output.WriteValueF32(Angle, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Normal.Deserialize(input, endianess);
			Compare = BaseProperty.DeserializePropertyEnum<CompareOperator>(input, endianess);
			Angle = input.ReadValueF32(endianess);
		}
	}
}
