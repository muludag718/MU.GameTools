using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.InHotZone)]
	public class InHotZoneCondition : P1Condition
	{
		public bool In { get; set; }

		public bool RequireStayOnGround { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueB32(In, endianess);
			output.WriteValueB32(RequireStayOnGround, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			In = input.ReadValueB32(endianess);
			RequireStayOnGround = input.ReadValueB32(endianess);
		}
	}
}
