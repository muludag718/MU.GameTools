using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.IntersectionProperties)]
	public class IntersectionPropertiesCondition : P1Condition
	{
		public enum IntersectionType : ulong
		{
			ColliderType = 7209654337809844792uL,
			CollideWithType = 6245265708753804894uL
		}

		public IntersectionType Intersection { get; set; }

		public ColliderType Colliders { get; set; }

		public bool Match { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Intersection);
			BaseProperty.SerializePropertyBitfield(output, endianess, Colliders);
			output.WriteValueB32(Match, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Intersection = BaseProperty.DeserializePropertyEnum<IntersectionType>(input, endianess);
			Colliders = BaseProperty.DeserializePropertyBitfield<ColliderType>(input, endianess);
			Match = input.ReadValueB32(endianess);
		}
	}
}
