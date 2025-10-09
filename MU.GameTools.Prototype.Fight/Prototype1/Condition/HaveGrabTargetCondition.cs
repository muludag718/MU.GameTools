using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.HaveGrabTarget)]
	public class HaveGrabTargetCondition : P1Condition
	{
		public bool Have { get; set; }

		public bool UseStoredProperties { get; set; }

		public ColliderType CollideWith { get; set; }

		public ColliderType Ignore { get; set; }

		public ulong ValidGrabbableClass { get; set; }

		public float Range { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueB32(Have, endianess);
			output.WriteValueB32(UseStoredProperties, endianess);
			BaseProperty.SerializePropertyBitfield(output, endianess, CollideWith);
			BaseProperty.SerializePropertyBitfield(output, endianess, Ignore);
			output.WriteValueU64(ValidGrabbableClass, endianess);
			output.WriteValueF32(Range, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Have = input.ReadValueB32(endianess);
			UseStoredProperties = input.ReadValueB32(endianess);
			CollideWith = BaseProperty.DeserializePropertyBitfield<ColliderType>(input, endianess);
			Ignore = BaseProperty.DeserializePropertyBitfield<ColliderType>(input, endianess);
			ValidGrabbableClass = input.ReadValueU64(endianess);
			Range = input.ReadValueF32(endianess);
		}
	}
}
