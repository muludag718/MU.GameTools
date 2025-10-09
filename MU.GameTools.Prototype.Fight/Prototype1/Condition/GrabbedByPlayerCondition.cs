using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.GrabbedByPlayer)]
	public class GrabbedByPlayerCondition : P1Condition
	{
		public bool IsGrabbedByPlayer { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueB32(IsGrabbedByPlayer, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			IsGrabbedByPlayer = input.ReadValueB32(endianess);
		}
	}
}
