using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.Engage)]
	public class EngageTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float MinStopDistance { get; set; }

		public float MaxStopDistance { get; set; }

		public float ExtraMoveDistance { get; set; }

		public float MinTimeInPosition { get; set; }

		public float MaxTimeInPosition { get; set; }

		public float MaxTimeMelee { get; set; }

		public float KneelingProbability { get; set; }

		public float MinSpeed { get; set; }

		public float MaxSpeed { get; set; }

		public ulong WeaponGrabSlot { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(MinStopDistance, endianess);
			output.WriteValueF32(MaxStopDistance, endianess);
			output.WriteValueF32(ExtraMoveDistance, endianess);
			output.WriteValueF32(MinTimeInPosition, endianess);
			output.WriteValueF32(MaxTimeInPosition, endianess);
			output.WriteValueF32(MaxTimeMelee, endianess);
			output.WriteValueF32(KneelingProbability, endianess);
			output.WriteValueF32(MinSpeed, endianess);
			output.WriteValueF32(MaxSpeed, endianess);
			output.WriteValueU64(WeaponGrabSlot, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			MinStopDistance = input.ReadValueF32(endianess);
			MaxStopDistance = input.ReadValueF32(endianess);
			ExtraMoveDistance = input.ReadValueF32(endianess);
			MinTimeInPosition = input.ReadValueF32(endianess);
			MaxTimeInPosition = input.ReadValueF32(endianess);
			MaxTimeMelee = input.ReadValueF32(endianess);
			KneelingProbability = input.ReadValueF32(endianess);
			MinSpeed = input.ReadValueF32(endianess);
			MaxSpeed = input.ReadValueF32(endianess);
			WeaponGrabSlot = input.ReadValueU64(endianess);
		}
	}
}
