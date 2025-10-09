using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.Mission)]
	public class MissionCondition : P1Condition
	{
		public int Episode { get; set; }

		public int Mission { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueS32(Episode, endianess);
			output.WriteValueS32(Mission, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Episode = input.ReadValueS32(endianess);
			Mission = input.ReadValueS32(endianess);
		}
	}
}
