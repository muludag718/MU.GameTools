using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.ReactionHitCollisionFlag)]
	public class ReactionHitCollisionFlagCondition : P1Condition
	{
		public ulong CollisionFlag { get; set; }

		public bool DoesMatch { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueU64(CollisionFlag, endianess);
			output.WriteValueB32(DoesMatch, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			CollisionFlag = input.ReadValueU64(endianess);
			DoesMatch = input.ReadValueB32(endianess);
		}
	}
}
