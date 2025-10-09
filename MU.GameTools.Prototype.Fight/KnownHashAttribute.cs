using System;

namespace MU.GameTools.Prototype.Fight
{
	public abstract class KnownHashAttribute : Attribute
	{
		public ulong Hash;

		public KnownHashAttribute(ulong hash)
		{
			Hash = hash;
		}
	}
}
