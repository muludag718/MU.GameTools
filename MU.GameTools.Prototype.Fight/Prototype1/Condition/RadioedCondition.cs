using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Alert)]
	[KnownCondition(ConditionHash.Radioed)]
	public class RadioedCondition : P1Condition
	{
		public bool Radioed { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueB32(Radioed, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Radioed = input.ReadValueB32(endianess);
		}
	}
}
