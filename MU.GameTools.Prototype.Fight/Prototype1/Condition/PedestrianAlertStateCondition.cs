using System;
using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.PedestrianAlertState)]
	public class PedestrianAlertStateCondition : P1Condition
	{
		[Flags]
		public enum PedReactState : ulong
		{
			None = 1uL,
			Explosion = 2uL,
			Throw = 4uL,
			Shapeshift = 8uL,
			Gunfire = 0x10uL,
			Grab = 0x20uL,
			Hit = 0x40uL,
			Shove = 0x80uL,
			ExtremeLocomotion = 0x100uL,
			Landing = 0x200uL,
			Consume = 0x400uL,
			Death = 0x800uL,
			BulletHit = 0x1000uL,
			ScatterPeds = 0x2000uL,
			MissileFire = 0x4000uL,
			PanickingPedestrian = 0x8000uL,
			DeadBody = 0x10000uL,
			GrabScream = 0x20000uL,
			FlyingObject = 0x40000uL,
			ThrowLand = 0x80000uL,
			EnterVehicle = 0x100000uL,
			GenerateDiversion = 0x200000uL,
			BurningVehicle = 0x400000uL,
			CarAccident = 0x800000uL
		}

		public bool Match { get; set; }

		public PedReactState State { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueB32(Match, endianess);
			BaseProperty.SerializePropertyBitfield(output, endianess, State);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Match = input.ReadValueB32(endianess);
			State = BaseProperty.DeserializePropertyBitfield<PedReactState>(input, endianess);
		}
	}
}
