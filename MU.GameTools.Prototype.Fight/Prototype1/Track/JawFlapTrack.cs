using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.JawFlap)]
	public class JawFlapTrack : P1Track
	{
		public float AngleMin { get; set; }

		public float AngleMax { get; set; }

		public float ThresholdMin { get; set; }

		public float ThresholdMax { get; set; }

		public ulong Joint { get; set; }

		public Vector Axis { get; set; } = new Vector();

		public int Priority { get; set; }

		public float BlendInTime { get; set; }

		public float BlendOutTime { get; set; }

		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(AngleMin, endianess);
			output.WriteValueF32(AngleMax, endianess);
			output.WriteValueF32(ThresholdMin, endianess);
			output.WriteValueF32(ThresholdMax, endianess);
			output.WriteValueU64(Joint, endianess);
			Axis.Serialize(output, endianess);
			output.WriteValueS32(Priority, endianess);
			output.WriteValueF32(BlendInTime, endianess);
			output.WriteValueF32(BlendOutTime, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			AngleMin = input.ReadValueF32(endianess);
			AngleMax = input.ReadValueF32(endianess);
			ThresholdMin = input.ReadValueF32(endianess);
			ThresholdMax = input.ReadValueF32(endianess);
			Joint = input.ReadValueU64(endianess);
			Axis.Deserialize(input, endianess);
			Priority = input.ReadValueS32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
		}
	}
}
