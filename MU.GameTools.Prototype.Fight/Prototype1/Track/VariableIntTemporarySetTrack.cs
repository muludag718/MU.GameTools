using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.VariableIntTemporarySet)]
	public class VariableIntTemporarySetTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public ulong Variable { get; set; }

		public ulong GrabSlot { get; set; }

		public bool UseGrabber { get; set; }

		public AssigmentOperator OperatorBegin { get; set; }

		public AssigmentOperator OperatorEnd { get; set; }

		public int BeginValue { get; set; }

		public int EndValue { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueU64(Variable, endianess);
			output.WriteValueU64(GrabSlot, endianess);
			output.WriteValueB32(UseGrabber, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, OperatorBegin);
			BaseProperty.SerializePropertyEnum(output, endianess, OperatorEnd);
			output.WriteValueS32(BeginValue, endianess);
			output.WriteValueS32(EndValue, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Variable = input.ReadValueU64(endianess);
			GrabSlot = input.ReadValueU64(endianess);
			UseGrabber = input.ReadValueB32(endianess);
			OperatorBegin = BaseProperty.DeserializePropertyEnum<AssigmentOperator>(input, endianess);
			OperatorEnd = BaseProperty.DeserializePropertyEnum<AssigmentOperator>(input, endianess);
			BeginValue = input.ReadValueS32(endianess);
			EndValue = input.ReadValueS32(endianess);
		}
	}
}
