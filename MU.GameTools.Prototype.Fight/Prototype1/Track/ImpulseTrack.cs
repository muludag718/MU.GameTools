using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.Impulse)]
	public class ImpulseTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public Vector Impulse { get; set; } = new Vector();

		public ulong Joint { get; set; }

		public Vector Offset { get; set; } = new Vector();

		public Vector Orientation { get; set; } = new Vector();

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			Impulse.Serialize(output, endianess);
			output.WriteValueU64(Joint, endianess);
			Offset.Serialize(output, endianess);
			Orientation.Serialize(output, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			Impulse = new Vector(input, endianess);
			Joint = input.ReadValueU64(endianess);
			Offset = new Vector(input, endianess);
			Orientation = new Vector(input, endianess);
		}
	}
}
