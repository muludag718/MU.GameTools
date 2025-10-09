using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Alert)]
	[KnownCondition(ConditionHash.Seen)]
	public class SeenCondition : P1Condition
	{
		public bool Seen { get; set; }

		public CompareOperator Since { get; set; }

		public float Time { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueB32(Seen, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Since);
			output.WriteValueF32(Time, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Seen = input.ReadValueB32(endianess);
			Since = BaseProperty.DeserializePropertyEnum<CompareOperator>(input, endianess);
			Time = input.ReadValueF32(endianess);
		}
	}
}
