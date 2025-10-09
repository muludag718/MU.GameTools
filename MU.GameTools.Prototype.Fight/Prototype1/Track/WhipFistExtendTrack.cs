using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.WhipFistExtend)]
	public class WhipFistExtendTrack : P1Track
	{
		public enum WhipfistExtendTargetType : ulong
		{
			Target = 856854631462190855uL,
			GrabTarget = 1754404701201221985uL
		}

		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float VelocityMin { get; set; }

		public float VelocityMax { get; set; }

		public float DistanceMin { get; set; }

		public float DistanceMax { get; set; }

		public float TrackingMin { get; set; }

		public float TrackingMax { get; set; }

		public float DamageMin { get; set; }

		public float DamageMax { get; set; }

		public float WaveSpeed { get; set; }

		public float WaveLength { get; set; }

		public float WaveAmplitude { get; set; }

		public float WaveAmplitudeRampUp { get; set; }

		public float WaveAmplitudeRampDown { get; set; }

		public float CorkscrewAngle { get; set; }

		public float CorkscrewRotationSpeed { get; set; }

		public float CorkscrewTravelingSpeed { get; set; }

		public WhipfistExtendTargetType Target { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(VelocityMin, endianess);
			output.WriteValueF32(VelocityMax, endianess);
			output.WriteValueF32(DistanceMin, endianess);
			output.WriteValueF32(DistanceMax, endianess);
			output.WriteValueF32(TrackingMin, endianess);
			output.WriteValueF32(TrackingMax, endianess);
			output.WriteValueF32(DamageMin, endianess);
			output.WriteValueF32(DamageMax, endianess);
			output.WriteValueF32(WaveSpeed, endianess);
			output.WriteValueF32(WaveLength, endianess);
			output.WriteValueF32(WaveAmplitude, endianess);
			output.WriteValueF32(WaveAmplitudeRampUp, endianess);
			output.WriteValueF32(WaveAmplitudeRampDown, endianess);
			output.WriteValueF32(CorkscrewAngle, endianess);
			output.WriteValueF32(CorkscrewRotationSpeed, endianess);
			output.WriteValueF32(CorkscrewTravelingSpeed, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Target);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			VelocityMin = input.ReadValueF32(endianess);
			VelocityMax = input.ReadValueF32(endianess);
			DistanceMin = input.ReadValueF32(endianess);
			DistanceMax = input.ReadValueF32(endianess);
			TrackingMin = input.ReadValueF32(endianess);
			TrackingMax = input.ReadValueF32(endianess);
			DamageMin = input.ReadValueF32(endianess);
			DamageMax = input.ReadValueF32(endianess);
			WaveSpeed = input.ReadValueF32(endianess);
			WaveLength = input.ReadValueF32(endianess);
			WaveAmplitude = input.ReadValueF32(endianess);
			WaveAmplitudeRampUp = input.ReadValueF32(endianess);
			WaveAmplitudeRampDown = input.ReadValueF32(endianess);
			CorkscrewAngle = input.ReadValueF32(endianess);
			CorkscrewRotationSpeed = input.ReadValueF32(endianess);
			CorkscrewTravelingSpeed = input.ReadValueF32(endianess);
			Target = BaseProperty.DeserializePropertyEnum<WhipfistExtendTargetType>(input, endianess);
		}
	}
}
