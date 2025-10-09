using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.VariableIntSet)]
	public class VariableIntSetTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public ulong Variable { get; set; }

		public AssigmentOperator Operator { get; set; }

		public int Value { get; set; }

		public bool Persistent { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueU64(Variable, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Operator);
			output.WriteValueS32(Value, endianess);
			output.WriteValueB32(Persistent, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			Variable = input.ReadValueU64(endianess);
			Operator = BaseProperty.DeserializePropertyEnum<AssigmentOperator>(input, endianess);
			Value = input.ReadValueS32(endianess);
			Persistent = input.ReadValueB32(endianess);
		}
	}
}
