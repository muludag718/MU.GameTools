using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.ScaleJointForConsume)]
	public class ScaleJointForConsumeTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public ulong JointToScale { get; set; }

		public float DesiredScale { get; set; }

		public float ScaleRate { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueU64(JointToScale, endianess);
			output.WriteValueF32(DesiredScale, endianess);
			output.WriteValueF32(ScaleRate, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			JointToScale = input.ReadValueU64(endianess);
			DesiredScale = input.ReadValueF32(endianess);
			ScaleRate = input.ReadValueF32(endianess);
		}
	}
}
