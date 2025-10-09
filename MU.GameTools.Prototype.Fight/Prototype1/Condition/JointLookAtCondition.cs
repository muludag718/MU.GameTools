using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.JointLookAt)]
	public class JointLookAtCondition : P1Condition
	{
		public ulong Joint { get; set; }

		public Vector Heading { get; set; } = new Vector();

		public Vector PrimaryRotationAxis { get; set; } = new Vector();

		public float PrimaryAngleMin { get; set; }

		public float PrimaryAngleMax { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueU64(Joint, endianess);
			Heading.Serialize(output, endianess);
			PrimaryRotationAxis.Serialize(output, endianess);
			output.WriteValueF32(PrimaryAngleMin, endianess);
			output.WriteValueF32(PrimaryAngleMax, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Joint = input.ReadValueU64(endianess);
			Heading.Deserialize(input, endianess);
			PrimaryRotationAxis.Deserialize(input, endianess);
			PrimaryAngleMin = input.ReadValueF32(endianess);
			PrimaryAngleMax = input.ReadValueF32(endianess);
		}
	}
}
