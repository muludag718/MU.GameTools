using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.MotionState)]
	public class MotionStateTrack : P1Track
	{
		public float BeginTime { get; set; }

		public MovementMotionState State { get; set; }

		public ulong Name { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(BeginTime, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, State);
			output.WriteValueU64(Name, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			BeginTime = input.ReadValueF32(endianess);
			State = BaseProperty.DeserializePropertyEnum<MovementMotionState>(input, endianess);
			Name = input.ReadValueU64(endianess);
		}
	}
}
