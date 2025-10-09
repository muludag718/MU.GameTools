using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.SupportingLimbTestSurfaceVelocityAngle)]
	public class SupportingLimbTestSurfaceVelocityAngleCondition : P1Condition
	{
		public VelocityOriginType VelocityType { get; set; }

		public Vector ZeroVector { get; set; } = new Vector();

		public float Angle { get; set; }

		public float Arc { get; set; }

		public bool UseExcessVelocity { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, VelocityType);
			ZeroVector.Serialize(output, endianess);
			output.WriteValueF32(Angle, endianess);
			output.WriteValueF32(Arc, endianess);
			output.WriteValueB32(UseExcessVelocity, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			VelocityType = BaseProperty.DeserializePropertyEnum<VelocityOriginType>(input, endianess);
			ZeroVector = new Vector(input, endianess);
			Angle = input.ReadValueF32(endianess);
			Arc = input.ReadValueF32(endianess);
			UseExcessVelocity = input.ReadValueB32(endianess);
		}
	}
}
