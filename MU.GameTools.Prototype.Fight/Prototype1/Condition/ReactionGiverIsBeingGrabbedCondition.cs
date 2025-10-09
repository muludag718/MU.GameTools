using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.ReactionGiverIsBeingGrabbed)]
	public class ReactionGiverIsBeingGrabbedCondition : P1Condition
	{
		public GrabType GrabType { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, GrabType);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			GrabType = BaseProperty.DeserializePropertyEnum<GrabType>(input, endianess);
		}
	}
}
