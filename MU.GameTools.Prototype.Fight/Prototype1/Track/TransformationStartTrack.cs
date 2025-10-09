using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.TransformStart)]
	public class TransformationStartTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public ulong SlotName { get; set; }

		public bool Stealthy { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueU64(SlotName, endianess);
			output.WriteValueB32(Stealthy, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			SlotName = input.ReadValueU64(endianess);
			Stealthy = input.ReadValueB32(endianess);
		}
	}
}
