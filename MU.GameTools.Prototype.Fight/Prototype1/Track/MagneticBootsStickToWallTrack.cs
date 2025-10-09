using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.MagneticBootsStickToWall)]
	public class MagneticBootsStickToWallTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float Speed { get; set; }

		public float Acceleration { get; set; }

		public float BeginTurn { get; set; }

		public float EndTurn { get; set; }

		public float VerticalOffset { get; set; }

		public int ChoreoPriority { get; set; }

		public float BlendInTime { get; set; }

		public float BlendOutTime { get; set; }

		public bool DebugDraw { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(Speed, endianess);
			output.WriteValueF32(Acceleration, endianess);
			output.WriteValueF32(BeginTurn, endianess);
			output.WriteValueF32(EndTurn, endianess);
			output.WriteValueF32(VerticalOffset, endianess);
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
			Speed = input.ReadValueF32(endianess);
			Acceleration = input.ReadValueF32(endianess);
			BeginTurn = input.ReadValueF32(endianess);
			EndTurn = input.ReadValueF32(endianess);
			VerticalOffset = input.ReadValueF32(endianess);
			ChoreoPriority = input.ReadValueS32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
			DebugDraw = input.ReadValueB32(endianess);
		}
	}
}
