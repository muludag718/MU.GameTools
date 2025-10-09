using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.ReactionHitCollisionNormal)]
	public class ReactionHitCollisionNormalCondition : P1Condition
	{
		public Vector Normal { get; set; } = new Vector();

		public float Arc { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			Normal.Serialize(output, endianess);
			output.WriteValueF32(Arc, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Normal.Deserialize(input, endianess);
			Arc = input.ReadValueF32(endianess);
		}
	}
}
