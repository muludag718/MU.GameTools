using System;

namespace MU.GameTools.Prototype.Fight;

[Flags]
public enum Collidables : ulong
{
	StaticObject = 1uL,
	SimulatedObject = 2uL,
	SupportingSurface = 4uL,
	Attachable = 8uL,
	Health = 0x10uL,
	HitReaction = 0x20uL,
	Prop = 0x40uL,
	CharacterSolver = 0x80uL,
	CauseDamage = 0x100uL,
	CauseHitReaction = 0x200uL,
	TriggerVolume = 0x400uL,
	Grabbable = 0x800uL,
	NavigationSimulatedObstacle = 0x1000uL,
	AmbientLookaheadVolume = 0x2000uL,
	PedBehaviour = 0x4000uL,
	VehicleBehaviour = 0x8000uL,
	Building = 0x10000uL,
	Dead = 0x20000uL,
	Tank = 0x40000uL,
	Walker = 0x80000uL,
	Flyer = 0x100000uL,
	Hunter = 0x200000uL,
	World = 0x400000uL,
	CharacterShield = 0x800000uL,
	District = 0x1000000uL,
	Zone = 0x2000000uL,
	Player = 0x4000000uL,
	CameraPop = 0x8000000uL,
	Shoveable = 0x10000000uL,
	Pole = 0x20000000uL,
	NISExclusionVolume = 0x40000000uL,
	NavigationStaticObstacle = 0x80000000uL
}
