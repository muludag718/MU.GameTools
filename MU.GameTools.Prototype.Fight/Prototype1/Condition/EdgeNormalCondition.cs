using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.EdgeNormal)]
	public class EdgeNormalCondition : P1Condition
	{
		public Vector Normal { get; set; } = new Vector();

		public float Arc { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			Normal.Serialize(output, endianess);
			output.WriteValueF32(Arc, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Normal = new Vector(input, endianess);
			Arc = input.ReadValueF32(endianess);
		}
	}
}
