using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.GrabbedExecuteOnParent)]
	public class GrabbedExecuteOnParentTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public BranchReference ReceiverBranch { get; set; } = new BranchReference();

		public int InterruptPriority { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			ReceiverBranch.Serialize(output, endianess);
			output.WriteValueS32(InterruptPriority, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			ReceiverBranch = new BranchReference(input, endianess);
			InterruptPriority = input.ReadValueS32(endianess);
		}
	}
}
