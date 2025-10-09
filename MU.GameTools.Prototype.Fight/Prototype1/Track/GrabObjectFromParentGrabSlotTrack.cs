using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.GrabObjectFromParentGrabSlot)]
	public class GrabObjectFromParentGrabSlotTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public ulong ParentSlot { get; set; }

		public ulong ChildSlot { get; set; }

		public int InterruptPriority { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueU64(ParentSlot, endianess);
			output.WriteValueU64(ChildSlot, endianess);
			output.WriteValueS32(InterruptPriority, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			ParentSlot = input.ReadValueU64(endianess);
			ChildSlot = input.ReadValueU64(endianess);
			InterruptPriority = input.ReadValueS32(endianess);
		}
	}
}
