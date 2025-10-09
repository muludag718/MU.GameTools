using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.ControlRoot)]
	public class ControlRootTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public bool MovementEnabled { get; set; }

		public float MaxSpeed { get; set; }

		public float Gravity { get; set; }

		public bool SteeringEnabled { get; set; }

		public float MaxTurnSpeed { get; set; }

		public int Priority { get; set; }

		public float BlendInTime { get; set; }

		public float BlendOutTime { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueB32(MovementEnabled, endianess);
			output.WriteValueF32(MaxSpeed, endianess);
			output.WriteValueF32(Gravity, endianess);
			output.WriteValueB32(SteeringEnabled, endianess);
			output.WriteValueF32(MaxTurnSpeed, endianess);
			output.WriteValueS32(Priority, endianess);
			output.WriteValueF32(BlendInTime, endianess);
			output.WriteValueF32(BlendOutTime, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			MovementEnabled = input.ReadValueB32(endianess);
			MaxSpeed = input.ReadValueF32(endianess);
			Gravity = input.ReadValueF32(endianess);
			SteeringEnabled = input.ReadValueB32(endianess);
			MaxTurnSpeed = input.ReadValueF32(endianess);
			Priority = input.ReadValueS32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
		}
	}
}
