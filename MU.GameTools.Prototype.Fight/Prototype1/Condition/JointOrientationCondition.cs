using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.JointOrientation)]
	public class JointOrientationCondition : P1Condition
	{
		public ulong Joint { get; set; }

		public Vector Facing { get; set; } = new Vector();

		public Vector Up { get; set; } = new Vector();

		public float Threshold { get; set; }

		public bool MatchFacing { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueU64(Joint, endianess);
			Facing.Serialize(output, endianess);
			Up.Serialize(output, endianess);
			output.WriteValueF32(Threshold, endianess);
			output.WriteValueB32(MatchFacing, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Joint = input.ReadValueU64(endianess);
			Facing.Deserialize(input, endianess);
			Up.Deserialize(input, endianess);
			Threshold = input.ReadValueF32(endianess);
			MatchFacing = input.ReadValueB32(endianess);
		}
	}
}
