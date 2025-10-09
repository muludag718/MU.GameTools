using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.SupportingLimbSurfaceIntersectionProperties)]
	public class SupportingLimbSurfaceIntersectionPropertiesCondition : P1Condition
	{
		public enum MatchType : ulong
		{
			any = 417410176246uL,
			all = 417410307425uL
		}

		public Collidables TestBits { get; set; }

		public MatchType MatchAgainst { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyBitfield(output, endianess, TestBits);
			BaseProperty.SerializePropertyEnum(output, endianess, MatchAgainst);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TestBits = BaseProperty.DeserializePropertyBitfield<Collidables>(input, endianess);
			MatchAgainst = BaseProperty.DeserializePropertyEnum<MatchType>(input, endianess);
		}
	}
}
