using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.FixedDestinationFlyto)]
	public class FixedDestinationFlytoTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float Tolerance { get; set; }

		public bool Braking { get; set; }

		public bool IgnoreRestrictions { get; set; }

		public bool ClearDestination { get; set; }

		public float FreeArea { get; set; }

		public float MinHeight { get; set; }

		public float MaxSpeed { get; set; }

		public Vector SpeedFactor { get; set; } = new Vector();

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(Tolerance, endianess);
			output.WriteValueB32(Braking, endianess);
			output.WriteValueB32(IgnoreRestrictions, endianess);
			output.WriteValueB32(ClearDestination, endianess);
			output.WriteValueF32(FreeArea, endianess);
			output.WriteValueF32(MinHeight, endianess);
			output.WriteValueF32(MaxSpeed, endianess);
			SpeedFactor.Serialize(output, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Tolerance = input.ReadValueF32(endianess);
			Braking = input.ReadValueB32(endianess);
			IgnoreRestrictions = input.ReadValueB32(endianess);
			ClearDestination = input.ReadValueB32(endianess);
			FreeArea = input.ReadValueF32(endianess);
			MinHeight = input.ReadValueF32(endianess);
			MaxSpeed = input.ReadValueF32(endianess);
			SpeedFactor.Deserialize(input, endianess);
		}
	}
}
