using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.Land)]
	public class LandTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float Speed { get; set; }

		public float ToleraceAngleStartLanding { get; set; }

		public bool ClearDestination { get; set; }

		public bool TurnOffRotor { get; set; }

		public bool IgnoreOrientation { get; set; }

		public float ToleranceY { get; set; }

		public float ToleranceXZ { get; set; }

		public float DistanceToGround { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(Speed, endianess);
			output.WriteValueF32(ToleraceAngleStartLanding, endianess);
			output.WriteValueB32(ClearDestination, endianess);
			output.WriteValueB32(TurnOffRotor, endianess);
			output.WriteValueB32(IgnoreOrientation, endianess);
			output.WriteValueF32(ToleranceY, endianess);
			output.WriteValueF32(ToleranceXZ, endianess);
			output.WriteValueF32(DistanceToGround, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Speed = input.ReadValueF32(endianess);
			ToleraceAngleStartLanding = input.ReadValueF32(endianess);
			ClearDestination = input.ReadValueB32(endianess);
			TurnOffRotor = input.ReadValueB32(endianess);
			IgnoreOrientation = input.ReadValueB32(endianess);
			ToleranceY = input.ReadValueF32(endianess);
			ToleranceXZ = input.ReadValueF32(endianess);
			DistanceToGround = input.ReadValueF32(endianess);
		}
	}
}
