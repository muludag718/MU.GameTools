using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.ShieldState)]
	public class ShieldStateCondition : P1Condition
	{
		public enum ShieldState : ulong
		{
			Healing = 3944994161688763534uL,
			Broken = 1179826529873802823uL,
			Deployed = 8467737584923706070uL,
			Deploying = 6760285816536298583uL,
			Retracted = 12955520895326110976uL,
			Retracting = 9268992573163848965uL
		}

		public ShieldState State { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, State);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			State = BaseProperty.DeserializePropertyEnum<ShieldState>(input, endianess);
		}
	}
}
