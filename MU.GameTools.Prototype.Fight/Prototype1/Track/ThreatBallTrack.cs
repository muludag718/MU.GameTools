using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.ThreatBall)]
	public class ThreatBallTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public Vector Offset { get; set; } = new Vector();

		public float Radius { get; set; }

		public float TimeToLive { get; set; }

		public ulong Joint { get; set; }

		public ulong ThreatName { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			Offset.Serialize(output, endianess);
			output.WriteValueF32(Radius, endianess);
			output.WriteValueF32(TimeToLive, endianess);
			output.WriteValueU64(Joint, endianess);
			output.WriteValueU64(ThreatName, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Offset = new Vector(input, endianess);
			Radius = input.ReadValueF32(endianess);
			TimeToLive = input.ReadValueF32(endianess);
			Joint = input.ReadValueU64(endianess);
			ThreatName = input.ReadValueU64(endianess);
		}
	}
}
