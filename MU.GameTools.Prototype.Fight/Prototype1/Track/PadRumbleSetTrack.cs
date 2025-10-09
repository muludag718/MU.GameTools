using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.PadRumbleSet)]
	public class PadRumbleSetTrack : P1Track
	{
		public enum MotorType : ulong
		{
			Primary = 1337333749093012630uL,
			Secondary = 17176159389396420574uL
		}

		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public MotorType Motor { get; set; }

		public float Scale { get; set; }

		public float FadeInTime { get; set; }

		public float HoldTime { get; set; }

		public float FadeOutTime { get; set; }

		public bool UseObjectPos { get; set; }

		public float FullIntensityRadius { get; set; }

		public float FallOffRadius { get; set; }

		public bool CancelOnTrackEnd { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Motor);
			output.WriteValueF32(Scale, endianess);
			output.WriteValueF32(FadeInTime, endianess);
			output.WriteValueF32(HoldTime, endianess);
			output.WriteValueF32(FadeOutTime, endianess);
			output.WriteValueB32(UseObjectPos, endianess);
			output.WriteValueF32(FullIntensityRadius, endianess);
			output.WriteValueF32(FallOffRadius, endianess);
			output.WriteValueB32(CancelOnTrackEnd, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Motor = BaseProperty.DeserializePropertyEnum<MotorType>(input, endianess);
			Scale = input.ReadValueF32(endianess);
			FadeInTime = input.ReadValueF32(endianess);
			HoldTime = input.ReadValueF32(endianess);
			FadeOutTime = input.ReadValueF32(endianess);
			UseObjectPos = input.ReadValueB32(endianess);
			FullIntensityRadius = input.ReadValueF32(endianess);
			FallOffRadius = input.ReadValueF32(endianess);
			CancelOnTrackEnd = input.ReadValueB32(endianess);
		}
	}
}
