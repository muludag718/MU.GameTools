using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.AimingAt)]
	public class AimingAtCondition : P1Condition
	{
		public ulong Joint { get; set; }

		public float Tolerance { get; set; }

		public bool Is3D { get; set; }

		public Vector Heading { get; set; } = new Vector();

		public Vector Offset { get; set; } = new Vector();

		public LookAtTarget Where { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueU64(Joint, endianess);
			output.WriteValueF32(Tolerance, endianess);
			output.WriteValueB32(Is3D, endianess);
			Heading.Serialize(output, endianess);
			Offset.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Where);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Joint = input.ReadValueU64(endianess);
			Tolerance = input.ReadValueF32(endianess);
			Is3D = input.ReadValueB32(endianess);
			Heading.Deserialize(input, endianess);
			Offset.Deserialize(input, endianess);
			Where = BaseProperty.DeserializePropertyEnum<LookAtTarget>(input, endianess);
		}
	}
}
