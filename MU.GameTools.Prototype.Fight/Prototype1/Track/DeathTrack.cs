using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.Death)]
	public class DeathTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public ulong DeadTemplate { get; set; }

		public bool CopyDrawable { get; set; }

		public bool GrabberIsOriginator { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueU64(DeadTemplate, endianess);
			output.WriteValueB32(CopyDrawable, endianess);
			output.WriteValueB32(GrabberIsOriginator, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			DeadTemplate = input.ReadValueU64(endianess);
			CopyDrawable = input.ReadValueB32(endianess);
			GrabberIsOriginator = input.ReadValueB32(endianess);
		}
	}
}
