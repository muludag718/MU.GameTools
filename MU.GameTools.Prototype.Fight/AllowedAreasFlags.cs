using System;

namespace MU.GameTools.Prototype.Fight
{
	[Flags]
	public enum AllowedAreasFlags : ulong
	{
		Unknown = 1uL,
		Intersection = 2uL,
		Road = 4uL,
		Crosswalk = 8uL,
		Sidewalk = 0x10uL,
		CrosswalkCorner = 0x20uL,
		Allyway = 0x40uL,
		Rooftop = 0x80uL
	}
}
