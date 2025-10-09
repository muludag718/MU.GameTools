using System;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public class KnownTypeAttribute : Attribute
	{
		public uint Id;

		public KnownTypeAttribute(uint id)
		{
			Id = id;
		}
	}
}
