using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;
using MU.GameTools.Prototype.Fight.Property;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.WallRunEnter)]
	public class WallRunEnterTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float TimeCancel { get; set; }

		public float VelocityXZMin { get; set; }

		public float VelocityXZMax { get; set; }

		public float VelocityUpMin { get; set; }

		public float VelocityUpMax { get; set; }

		public float TurningVelocityMin { get; set; }

		public float TurningVelocityMax { get; set; }

		public float TurningAccelerationMin { get; set; }

		public float TurningAccelerationMax { get; set; }

		public float SurfaceDistance { get; set; }

		public float SurfacePushoutVelocityMax { get; set; }

		public int Priority { get; set; }

		public float BlendInTime { get; set; }

		public float BlendOutTime { get; set; }

		public BranchReference Branch { get; set; } = new BranchReference();

		public int InterruptPriority { get; set; }

		public PropertyConditionGroup Conditions { get; set; } = new PropertyConditionGroup(PropertyHash.Conditions);

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(TimeCancel, endianess);
			output.WriteValueF32(VelocityXZMin, endianess);
			output.WriteValueF32(VelocityXZMax, endianess);
			output.WriteValueF32(VelocityUpMin, endianess);
			output.WriteValueF32(VelocityUpMax, endianess);
			output.WriteValueF32(TurningVelocityMin, endianess);
			output.WriteValueF32(TurningVelocityMax, endianess);
			output.WriteValueF32(TurningAccelerationMin, endianess);
			output.WriteValueF32(TurningAccelerationMax, endianess);
			output.WriteValueF32(SurfaceDistance, endianess);
			output.WriteValueF32(SurfacePushoutVelocityMax, endianess);
			output.WriteValueS32(Priority, endianess);
			output.WriteValueF32(BlendInTime, endianess);
			output.WriteValueF32(BlendOutTime, endianess);
			Branch.Serialize(output, endianess);
			output.WriteValueS32(InterruptPriority, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			TimeCancel = input.ReadValueF32(endianess);
			VelocityXZMin = input.ReadValueF32(endianess);
			VelocityXZMax = input.ReadValueF32(endianess);
			VelocityUpMin = input.ReadValueF32(endianess);
			VelocityUpMax = input.ReadValueF32(endianess);
			TurningVelocityMin = input.ReadValueF32(endianess);
			TurningVelocityMax = input.ReadValueF32(endianess);
			TurningAccelerationMin = input.ReadValueF32(endianess);
			TurningAccelerationMax = input.ReadValueF32(endianess);
			SurfaceDistance = input.ReadValueF32(endianess);
			SurfacePushoutVelocityMax = input.ReadValueF32(endianess);
			Priority = input.ReadValueS32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
			Branch = new BranchReference(input, endianess);
			InterruptPriority = input.ReadValueS32(endianess);
		}

		public override void SerializeProperties(PrototypeGame game, Stream output, Endian endianess)
		{
			BaseProperty.SerializeBaseProperty(PrototypeGame.P1, output, endianess, Conditions);
		}

		public override void DeserializeProperties(PrototypeGame game, Stream input, Endian endianess)
		{
			Conditions = BaseProperty.DeserializeConditionProperty(PrototypeGame.P1, input, endianess, PropertyHash.Conditions);
		}
	}
}
