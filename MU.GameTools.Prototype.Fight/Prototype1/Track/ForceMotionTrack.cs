using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.ForceMotion)]
	public class ForceMotionTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public Vector Motion { get; set; } = new Vector();

		public bool Local { get; set; }

		public float AccelerationFactor { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			Motion.Serialize(output, endianess);
			output.WriteValueB32(Local, endianess);
			output.WriteValueF32(AccelerationFactor, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Motion.Deserialize(input, endianess);
			Local = input.ReadValueB32(endianess);
			AccelerationFactor = input.ReadValueF32(endianess);
		}
	}
}
