using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.ShootingEvent)]
	public class ShootingEventCondition : P1Condition
	{
		public enum ShootingEventType : ulong
		{
			ShootBegin = 3674486027934643056uL,
			ShootEnd = 7583024027496011076uL,
			ShotFired = 12142346295941938800uL,
			ClipEmpty = 12678760736155385221uL,
			Discarded = 1339307571350710661uL,
			PickedUp = 16979082672551358635uL
		}

		public ShootingEventType Event { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Event);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Event = BaseProperty.DeserializePropertyEnum<ShootingEventType>(input, endianess);
		}
	}
}
