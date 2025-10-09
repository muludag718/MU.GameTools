using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.FromMuscleMass)]
	public class FromMuscleMassCondition : P1Condition
	{
		public bool MuscleMassActive { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueB32(MuscleMassActive, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			MuscleMassActive = input.ReadValueB32(endianess);
		}
	}
}
