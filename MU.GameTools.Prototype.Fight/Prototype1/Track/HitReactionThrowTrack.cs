using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.HitReactionThrow)]
	public class HitReactionThrowTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float AutoTargetArc { get; set; }

		public float MaxTargetArc { get; set; }

		public float DistanceMin { get; set; }

		public float DistanceMax { get; set; }

		public float VelocityMin { get; set; }

		public float VelocityMax { get; set; }

		public float TrackingMin { get; set; }

		public float TrackingMax { get; set; }

		public float SpinMin { get; set; }

		public float SpinMax { get; set; }

		public float ArcRange { get; set; }

		public float ArcMax { get; set; }

		public float DamageMin { get; set; }

		public float DamageMax { get; set; }

		public float ImpulseMin { get; set; }

		public float ImpulseMax { get; set; }

		public float FriendlyFire { get; set; }

		public ulong HitType { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(AutoTargetArc, endianess);
			output.WriteValueF32(MaxTargetArc, endianess);
			output.WriteValueF32(DistanceMin, endianess);
			output.WriteValueF32(DistanceMax, endianess);
			output.WriteValueF32(VelocityMin, endianess);
			output.WriteValueF32(VelocityMax, endianess);
			output.WriteValueF32(TrackingMin, endianess);
			output.WriteValueF32(TrackingMax, endianess);
			output.WriteValueF32(SpinMin, endianess);
			output.WriteValueF32(SpinMax, endianess);
			output.WriteValueF32(ArcRange, endianess);
			output.WriteValueF32(ArcMax, endianess);
			output.WriteValueF32(DamageMin, endianess);
			output.WriteValueF32(DamageMax, endianess);
			output.WriteValueF32(ImpulseMin, endianess);
			output.WriteValueF32(ImpulseMax, endianess);
			output.WriteValueF32(FriendlyFire, endianess);
			output.WriteValueU64(HitType, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			AutoTargetArc = input.ReadValueF32(endianess);
			MaxTargetArc = input.ReadValueF32(endianess);
			DistanceMin = input.ReadValueF32(endianess);
			DistanceMax = input.ReadValueF32(endianess);
			VelocityMin = input.ReadValueF32(endianess);
			VelocityMax = input.ReadValueF32(endianess);
			TrackingMin = input.ReadValueF32(endianess);
			TrackingMax = input.ReadValueF32(endianess);
			SpinMin = input.ReadValueF32(endianess);
			SpinMax = input.ReadValueF32(endianess);
			ArcRange = input.ReadValueF32(endianess);
			ArcMax = input.ReadValueF32(endianess);
			DamageMin = input.ReadValueF32(endianess);
			DamageMax = input.ReadValueF32(endianess);
			ImpulseMin = input.ReadValueF32(endianess);
			ImpulseMax = input.ReadValueF32(endianess);
			FriendlyFire = input.ReadValueF32(endianess);
			HitType = input.ReadValueU64(endianess);
		}
	}
}
