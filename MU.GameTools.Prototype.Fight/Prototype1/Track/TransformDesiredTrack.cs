using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.TransformDesired)]
	public class TransformDesiredTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public ulong SlotName { get; set; }

		public ulong TransformationDescription { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueU64(SlotName, endianess);
			output.WriteValueU64(TransformationDescription, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			SlotName = input.ReadValueU64(endianess);
			TransformationDescription = input.ReadValueU64(endianess);
		}
	}
}
