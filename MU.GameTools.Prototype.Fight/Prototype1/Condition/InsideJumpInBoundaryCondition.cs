using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.InsideJumpInBoundary)]
	public class InsideJumpInBoundaryCondition : P1Condition
	{
		public bool InsideJumpInBoundary { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueB32(InsideJumpInBoundary, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			InsideJumpInBoundary = input.ReadValueB32(endianess);
		}
	}
}
