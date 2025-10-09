using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.GrabSlotSwap)]
	public class GrabSlotSwapTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public ulong SlotA { get; set; }

		public ulong SlotB { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueU64(SlotA, endianess);
			output.WriteValueU64(SlotB, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			SlotA = input.ReadValueU64(endianess);
			SlotB = input.ReadValueU64(endianess);
		}
	}
}
