using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.AI)]
	[KnownTrack(TrackHash.DestinationFlyTo)]
	public class DestinationFlyToTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float Tolerance { get; set; }

		public bool Brake { get; set; }

		public bool IgnoreRestrictions { get; set; }

		public float FreeArea { get; set; }

		public float MinHeight { get; set; }

		public float MaxSpeed { get; set; }

		public Vector SpeedFactor { get; set; } = new Vector();

		public int TurningFactorA { get; set; }

		public int TurningFactorB { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(Tolerance, endianess);
			output.WriteValueB32(Brake, endianess);
			output.WriteValueB32(IgnoreRestrictions, endianess);
			output.WriteValueF32(FreeArea, endianess);
			output.WriteValueF32(MinHeight, endianess);
			output.WriteValueF32(MaxSpeed, endianess);
			SpeedFactor.Serialize(output, endianess);
			output.WriteValueS32(TurningFactorA, endianess);
			output.WriteValueS32(TurningFactorB, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Tolerance = input.ReadValueF32(endianess);
			Brake = input.ReadValueB32(endianess);
			IgnoreRestrictions = input.ReadValueB32(endianess);
			FreeArea = input.ReadValueF32(endianess);
			MinHeight = input.ReadValueF32(endianess);
			MaxSpeed = input.ReadValueF32(endianess);
			SpeedFactor = new Vector(input, endianess);
			TurningFactorA = input.ReadValueS32(endianess);
			TurningFactorB = input.ReadValueS32(endianess);
		}
	}
}
