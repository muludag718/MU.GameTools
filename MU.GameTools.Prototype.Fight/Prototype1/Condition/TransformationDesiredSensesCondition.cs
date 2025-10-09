using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.TransformationDesiredSenses)]
	public class TransformationDesiredSensesCondition : P1Condition
	{
		public bool ThermalVisionDesired { get; set; }

		public bool InfectedVisionDesired { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueB32(ThermalVisionDesired, endianess);
			output.WriteValueB32(InfectedVisionDesired, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			ThermalVisionDesired = input.ReadValueB32(endianess);
			InfectedVisionDesired = input.ReadValueB32(endianess);
		}
	}
}
