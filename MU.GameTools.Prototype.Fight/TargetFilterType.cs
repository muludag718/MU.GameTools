using System;

namespace MU.GameTools.Prototype.Fight
{
	[Flags]
	public enum TargetFilterType : ulong
	{
		LockOn = 1uL,
		AttackMelee = 2uL,
		AttackRanged = 4uL,
		Grab = 8uL,
		Feet = 0x10uL,
		AlertObject = 0x20uL
	}
}
