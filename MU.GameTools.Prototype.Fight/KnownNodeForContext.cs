using System;

namespace MU.GameTools.Prototype.Fight
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public class KnownNodeForContext : Attribute
	{
		public ulong ContextHash;

		public KnownNodeForContext(ulong contextHash)
		{
			ContextHash = contextHash;
		}

		public KnownNodeForContext(ContextHash contextHash)
		{
			ContextHash = (ulong)contextHash;
		}
	}
}
