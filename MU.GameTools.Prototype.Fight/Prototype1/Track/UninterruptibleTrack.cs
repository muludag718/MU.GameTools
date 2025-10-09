using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.Uninterruptible)]
	public class UninterruptibleTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public bool IgnoreHits { get; set; }

		public bool IgnoreGrabs { get; set; }

		public bool AllowDevastatorGrabs { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueB32(IgnoreHits, endianess);
			output.WriteValueB32(IgnoreGrabs, endianess);
			output.WriteValueB32(AllowDevastatorGrabs, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			IgnoreHits = input.ReadValueB32(endianess);
			IgnoreGrabs = input.ReadValueB32(endianess);
			AllowDevastatorGrabs = input.ReadValueB32(endianess);
		}
	}
}
