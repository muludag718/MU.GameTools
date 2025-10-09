using System;

namespace MU.GameTools.Prototype.Fight
{
	[Flags]
	public enum ColliderType : ulong
	{
		Reserved = 1uL,
		StaticObject = 2uL,
		StaticObjectHighVelocity = 4uL,
		SimulatedObject = 8uL,
		SupportingSurface = 0x10uL,
		Attachable = 0x20uL,
		Health = 0x40uL,
		HitReaction = 0x80uL,
		Prop = 0x100uL,
		CharacterSolver = 0x200uL,
		CauseDamage = 0x400uL,
		CauseHitReaction = 0x800uL,
		TriggerVolume = 0x1000uL,
		Camera = 0x2000uL,
		CameraPop = 0x4000uL,
		CameraFade = 0x8000uL,
		Grabbable = 0x10000uL,
		NavigationSimulatedObstacle = 0x20000uL,
		AmbientLookaheadVolume = 0x40000uL,
		PedBehaviour = 0x80000uL,
		VehicleBehaviour = 0x100000uL,
		Dead = 0x200000uL,
		Tank = 0x400000uL,
		Walker = 0x800000uL,
		Flyer = 0x1000000uL,
		Hunter = 0x2000000uL,
		World = 0x4000000uL,
		CharacterShield = 0x8000000uL,
		Water = 0x10000000uL,
		Zone = 0x20000000uL,
		Player = 0x40000000uL,
		Shoveable = 0x80000000uL,
		Pole = 0x100000000uL,
		NISExclusionVolume = 0x200000000uL,
		NavigationStaticObstacle = 0x400000000uL
	}
}
