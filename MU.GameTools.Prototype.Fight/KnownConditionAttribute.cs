using System;

namespace MU.GameTools.Prototype.Fight
{
	[AttributeUsage(AttributeTargets.Class)]
	public class KnownConditionAttribute : KnownHashAttribute
	{
		public KnownConditionAttribute(ulong hash)
			: base(hash)
		{
		}

		public KnownConditionAttribute(ConditionHash hashEnum)
			: base((ulong)hashEnum)
		{
		}
	}
}
