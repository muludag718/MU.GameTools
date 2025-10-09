using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.Throw)]
	public class ThrowTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public ulong GrabSlot { get; set; }

		public float DirectionX { get; set; }

		public float DirectionY { get; set; }

		public float DirectionZ { get; set; }

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

		public bool UseTarget { get; set; }

		public bool UseTargetVehicle { get; set; }

		public float RandomOffset { get; set; }

		public int InterruptPriority { get; set; }

		public ulong HitType { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueU64(GrabSlot, endianess);
			output.WriteValueF32(DirectionX, endianess);
			output.WriteValueF32(DirectionY, endianess);
			output.WriteValueF32(DirectionZ, endianess);
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
			output.WriteValueB32(UseTarget, endianess);
			output.WriteValueB32(UseTargetVehicle, endianess);
			output.WriteValueF32(RandomOffset, endianess);
			output.WriteValueS32(InterruptPriority, endianess);
			output.WriteValueU64(HitType, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			GrabSlot = input.ReadValueU64(endianess);
			DirectionX = input.ReadValueF32(endianess);
			DirectionY = input.ReadValueF32(endianess);
			DirectionZ = input.ReadValueF32(endianess);
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
			UseTarget = input.ReadValueB32(endianess);
			UseTargetVehicle = input.ReadValueB32(endianess);
			RandomOffset = input.ReadValueF32(endianess);
			InterruptPriority = input.ReadValueS32(endianess);
			HitType = input.ReadValueU64(endianess);
		}
	}
}
