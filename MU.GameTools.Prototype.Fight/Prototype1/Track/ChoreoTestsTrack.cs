using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.ChoreoTests)]
	public class ChoreoTestsTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public bool TestRandomSteer { get; set; }

		public bool TestPoseDriver { get; set; }

		public bool TestRestPoseDriver { get; set; }

		public bool TestDriverCopy { get; set; }

		public ulong TestDriverCopySource { get; set; }

		public int Priority { get; set; }

		public float BlendInTime { get; set; }

		public float BlendOutTime { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueB32(TestRandomSteer, endianess);
			output.WriteValueB32(TestPoseDriver, endianess);
			output.WriteValueB32(TestRestPoseDriver, endianess);
			output.WriteValueB32(TestDriverCopy, endianess);
			output.WriteValueU64(TestDriverCopySource, endianess);
			output.WriteValueS32(Priority, endianess);
			output.WriteValueF32(BlendInTime, endianess);
			output.WriteValueF32(BlendOutTime, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			TestRandomSteer = input.ReadValueB32(endianess);
			TestPoseDriver = input.ReadValueB32(endianess);
			TestRestPoseDriver = input.ReadValueB32(endianess);
			TestDriverCopy = input.ReadValueB32(endianess);
			TestDriverCopySource = input.ReadValueU64(endianess);
			Priority = input.ReadValueS32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
		}
	}
}
