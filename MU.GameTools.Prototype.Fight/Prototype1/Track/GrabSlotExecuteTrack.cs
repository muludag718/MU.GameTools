using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.GrabSlotExecute)]
	public class GrabSlotExecuteTrack : P1Track
	{
		public float BeginTime { get; set; }

		public ulong GrabSlotName { get; set; }

		public BranchReference ReceiverBranchRef { get; set; } = new BranchReference();

		public int InterruptPriority { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(BeginTime, endianess);
			output.WriteValueU64(GrabSlotName, endianess);
			ReceiverBranchRef.Serialize(output, endianess);
			output.WriteValueS32(InterruptPriority, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			BeginTime = input.ReadValueF32(endianess);
			GrabSlotName = input.ReadValueU64(endianess);
			ReceiverBranchRef = new BranchReference(input, endianess);
			InterruptPriority = input.ReadValueS32(endianess);
		}
	}
}
