using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;
using MU.GameTools.Prototype.Fight.Property;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.TendrilFromParent)]
	public class TendrilFromParentTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeReverse { get; set; }

		public float TimeEnd { get; set; }

		public ulong Drawable { get; set; }

		public float Scale { get; set; }

		public bool KeepGoing { get; set; }

		public float HitRadius { get; set; }

		public float TrackingVelocity { get; set; }

		public float TrackingDeceleration { get; set; }

		public bool SwapDirection { get; set; }

		public bool StaticEndPoint { get; set; }

		public ulong StartJoint { get; set; }

		public Vector StartJointOffset { get; set; } = new Vector();

		public ulong GrabSlotJoint { get; set; }

		public Vector GrabSlotJointOffset { get; set; } = new Vector();

		public float ForwardVelocity { get; set; }

		public float ReverseVelocity { get; set; }

		public float CircleRadius { get; set; }

		public float ZAxisRotation { get; set; }

		public float XAxisRotation { get; set; }

		public int SegmentCount { get; set; }

		public float WaveSpeed { get; set; }

		public float WaveLength { get; set; }

		public float WaveAmplitude { get; set; }

		public float WaveAmplitudeRampUp { get; set; }

		public float WaveAmplitudeRampDown { get; set; }

		public float CorkscrewAngle { get; set; }

		public float CorkscrewRotationSpeed { get; set; }

		public float CorkscrewTravelingSpeed { get; set; }

		public float DevastatorDamageMultiplier { get; set; }

		public float TimeBetweenHits { get; set; }

		public PropertyConditionGroup ReverseConditions { get; set; } = new PropertyConditionGroup(PropertyHash.ReverseConditions);

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeReverse, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueU64(Drawable, endianess);
			output.WriteValueF32(Scale, endianess);
			output.WriteValueB32(KeepGoing, endianess);
			output.WriteValueF32(HitRadius, endianess);
			output.WriteValueF32(TrackingVelocity, endianess);
			output.WriteValueF32(TrackingDeceleration, endianess);
			output.WriteValueB32(SwapDirection, endianess);
			output.WriteValueB32(StaticEndPoint, endianess);
			output.WriteValueU64(StartJoint, endianess);
			StartJointOffset.Serialize(output, endianess);
			output.WriteValueU64(GrabSlotJoint, endianess);
			GrabSlotJointOffset.Serialize(output, endianess);
			output.WriteValueF32(ForwardVelocity, endianess);
			output.WriteValueF32(ReverseVelocity, endianess);
			output.WriteValueF32(CircleRadius, endianess);
			output.WriteValueF32(ZAxisRotation, endianess);
			output.WriteValueF32(XAxisRotation, endianess);
			output.WriteValueS32(SegmentCount, endianess);
			output.WriteValueF32(WaveSpeed, endianess);
			output.WriteValueF32(WaveLength, endianess);
			output.WriteValueF32(WaveAmplitude, endianess);
			output.WriteValueF32(WaveAmplitudeRampUp, endianess);
			output.WriteValueF32(WaveAmplitudeRampDown, endianess);
			output.WriteValueF32(CorkscrewAngle, endianess);
			output.WriteValueF32(CorkscrewRotationSpeed, endianess);
			output.WriteValueF32(CorkscrewTravelingSpeed, endianess);
			output.WriteValueF32(DevastatorDamageMultiplier, endianess);
			output.WriteValueF32(TimeBetweenHits, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeReverse = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Drawable = input.ReadValueU64(endianess);
			Scale = input.ReadValueF32(endianess);
			KeepGoing = input.ReadValueB32(endianess);
			HitRadius = input.ReadValueF32(endianess);
			TrackingVelocity = input.ReadValueF32(endianess);
			TrackingDeceleration = input.ReadValueF32(endianess);
			SwapDirection = input.ReadValueB32(endianess);
			StaticEndPoint = input.ReadValueB32(endianess);
			StartJoint = input.ReadValueU64(endianess);
			StartJointOffset = new Vector(input, endianess);
			GrabSlotJoint = input.ReadValueU64(endianess);
			GrabSlotJointOffset = new Vector(input, endianess);
			ForwardVelocity = input.ReadValueF32(endianess);
			ReverseVelocity = input.ReadValueF32(endianess);
			CircleRadius = input.ReadValueF32(endianess);
			ZAxisRotation = input.ReadValueF32(endianess);
			XAxisRotation = input.ReadValueF32(endianess);
			SegmentCount = input.ReadValueS32(endianess);
			WaveSpeed = input.ReadValueF32(endianess);
			WaveLength = input.ReadValueF32(endianess);
			WaveAmplitude = input.ReadValueF32(endianess);
			WaveAmplitudeRampUp = input.ReadValueF32(endianess);
			WaveAmplitudeRampDown = input.ReadValueF32(endianess);
			CorkscrewAngle = input.ReadValueF32(endianess);
			CorkscrewRotationSpeed = input.ReadValueF32(endianess);
			CorkscrewTravelingSpeed = input.ReadValueF32(endianess);
			DevastatorDamageMultiplier = input.ReadValueF32(endianess);
			TimeBetweenHits = input.ReadValueF32(endianess);
		}

		public override void SerializeProperties(PrototypeGame game, Stream output, Endian endianess)
		{
			BaseProperty.SerializeBaseProperty(PrototypeGame.P1, output, endianess, ReverseConditions);
		}

		public override void DeserializeProperties(PrototypeGame game, Stream input, Endian endianess)
		{
			ReverseConditions = BaseProperty.DeserializeConditionProperty(PrototypeGame.P1, input, endianess, PropertyHash.ReverseConditions);
		}
	}
}
