using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.SupportingLimbTestSwitchSurfaces)]
	public class SupportingLimbTestSwitchSurfacesCondition : P1Condition
	{
		public bool SwitchSurfaces { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueB32(SwitchSurfaces, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			SwitchSurfaces = input.ReadValueB32(endianess);
		}
	}
}
