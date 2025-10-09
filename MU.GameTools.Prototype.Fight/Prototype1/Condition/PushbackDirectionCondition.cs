using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.PushbackDirection)]
	public class PushbackDirectionCondition : P1Condition
	{
		public float Direction { get; set; }

		public float Arc { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(Direction, endianess);
			output.WriteValueF32(Arc, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Direction = input.ReadValueF32(endianess);
			Arc = input.ReadValueF32(endianess);
		}
	}
}
