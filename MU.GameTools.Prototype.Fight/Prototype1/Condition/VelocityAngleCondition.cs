using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.VelocityAngle)]
	public class VelocityAngleCondition : P1Condition
	{
		public VelocityOriginType Type { get; set; }

		public CompareOperator CompareTime { get; set; }

		public float Angle { get; set; }

		public bool XZ { get; set; }

		public bool Signed { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Type);
			BaseProperty.SerializePropertyEnum(output, endianess, CompareTime);
			output.WriteValueF32(Angle, endianess);
			output.WriteValueB32(XZ, endianess);
			output.WriteValueB32(Signed, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Type = BaseProperty.DeserializePropertyEnum<VelocityOriginType>(input, endianess);
			CompareTime = BaseProperty.DeserializePropertyEnum<CompareOperator>(input, endianess);
			Angle = input.ReadValueF32(endianess);
			XZ = input.ReadValueB32(endianess);
			Signed = input.ReadValueB32(endianess);
		}
	}
}
