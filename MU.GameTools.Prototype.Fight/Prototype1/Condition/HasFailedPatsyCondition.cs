using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Alert)]
	[KnownCondition(ConditionHash.HasFailedPatsy)]
	public class HasFailedPatsyCondition : P1Condition
	{
		public bool Has { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueB32(Has, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Has = input.ReadValueB32(endianess);
		}
	}
}
