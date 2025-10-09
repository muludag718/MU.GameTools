using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.Unlockable)]
	public class UnlockableCondition : P1Condition
	{
		public UnlockableEnum UnlockableType { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, UnlockableType);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			UnlockableType = BaseProperty.DeserializePropertyEnum<UnlockableEnum>(input, endianess);
		}
	}
}
