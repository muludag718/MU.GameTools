using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.ObstacleColliderType)]
	public class ObstacleColliderTypeCondition : P1Condition
	{
		public enum ContainType : ulong
		{
			Contains = 6634170926787241387uL,
			DoesNotContain = 13301905139068269446uL
		}

		public ContainType Compare { get; set; }

		public ColliderType ColliderType { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Compare);
			BaseProperty.SerializePropertyBitfield(output, endianess, ColliderType);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Compare = BaseProperty.DeserializePropertyEnum<ContainType>(input, endianess);
			ColliderType = BaseProperty.DeserializePropertyBitfield<ColliderType>(input, endianess);
		}
	}
}
