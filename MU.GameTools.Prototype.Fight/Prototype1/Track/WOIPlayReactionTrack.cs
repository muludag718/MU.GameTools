using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.WOIPlayReaction)]
	public class WOIPlayReactionTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public ulong TargetGrabSlot { get; set; }

		public BranchReference WoiBranch { get; set; } = new BranchReference();

		public int Priority { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueU64(TargetGrabSlot, endianess);
			WoiBranch.Serialize(output, endianess);
			output.WriteValueS32(Priority, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TargetGrabSlot = input.ReadValueU64(endianess);
			WoiBranch = new BranchReference(input, endianess);
			Priority = input.ReadValueS32(endianess);
		}
	}
}
