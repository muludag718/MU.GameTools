using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.HitSurface)]
	public class HitSurfaceCondition : P1Condition
	{
		public enum HitSurfaceType : ulong
		{
			Ground = 11389985536937095513uL,
			Roof = 23147657255643158uL,
			Wall = 24558595612407808uL
		}

		public HitSurfaceType Surface { get; set; }

		public bool HitSurface { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Surface);
			output.WriteValueB32(HitSurface, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Surface = BaseProperty.DeserializePropertyEnum<HitSurfaceType>(input, endianess);
			HitSurface = input.ReadValueB32(endianess);
		}
	}
}
