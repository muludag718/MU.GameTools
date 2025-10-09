using System;

namespace MU.GameTools.Prototype.Fight
{
	[Flags]
	public enum AnimationAllowedTransitionsType : ulong
	{
		North = 1uL,
		East = 2uL,
		South = 4uL,
		West = 8uL
	}
}
