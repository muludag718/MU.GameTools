using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.DevastatorTargetGroundSpike)]
	public class DevastatorTargetGroundSpikeTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public ulong Template { get; set; }

		public int Parameter { get; set; }

		public bool Random { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueU64(Template, endianess);
			output.WriteValueS32(Parameter, endianess);
			output.WriteValueB32(Random, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			Template = input.ReadValueU64(endianess);
			Parameter = input.ReadValueS32(endianess);
			Random = input.ReadValueB32(endianess);
		}
	}
}
