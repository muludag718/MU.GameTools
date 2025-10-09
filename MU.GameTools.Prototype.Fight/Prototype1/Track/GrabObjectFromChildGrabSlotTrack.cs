using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.GrabObjectFromChildGrabSlot)]
	public class GrabObjectFromChildGrabSlotTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public ulong Child { get; set; }

		public ulong ChildGrabSlot { get; set; }

		public ulong GrabSlot { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueU64(Child, endianess);
			output.WriteValueU64(ChildGrabSlot, endianess);
			output.WriteValueU64(GrabSlot, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			Child = input.ReadValueU64(endianess);
			ChildGrabSlot = input.ReadValueU64(endianess);
			GrabSlot = input.ReadValueU64(endianess);
		}
	}
}
