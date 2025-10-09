using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.MagneticBootsDetach)]
	public class MagneticBootsDetachTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float Time { get; set; }

		public float Separation { get; set; }

		public int ChoreoPriority { get; set; }

		public float BlendInTime { get; set; }

		public float BlendOutTime { get; set; }

		public bool DebugDraw { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(Time, endianess);
			output.WriteValueF32(Separation, endianess);
			output.WriteValueS32(ChoreoPriority, endianess);
			output.WriteValueF32(BlendInTime, endianess);
			output.WriteValueF32(BlendOutTime, endianess);
			output.WriteValueB32(DebugDraw, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Time = input.ReadValueF32(endianess);
			Separation = input.ReadValueF32(endianess);
			ChoreoPriority = input.ReadValueS32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
			DebugDraw = input.ReadValueB32(endianess);
		}
	}
}
