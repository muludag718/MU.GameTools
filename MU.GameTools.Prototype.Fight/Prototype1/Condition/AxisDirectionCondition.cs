using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.AxisDirection)]
	public class AxisDirectionCondition : P1Condition
	{
		public Axis Axis { get; set; }

		public float Direction { get; set; }

		public float Arc { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Axis);
			output.WriteValueF32(Direction, endianess);
			output.WriteValueF32(Arc, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Axis = BaseProperty.DeserializePropertyEnum<Axis>(input, endianess);
			Direction = input.ReadValueF32(endianess);
			Arc = input.ReadValueF32(endianess);
		}
	}
}
