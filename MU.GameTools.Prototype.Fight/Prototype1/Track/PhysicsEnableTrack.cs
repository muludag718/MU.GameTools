using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.PhysicsEnable)]
	public class PhysicsEnableTrack : P1Track
	{
		public enum PhysicsEnableActionType : ulong
		{
			DoNothing = 3876518407870578744uL,
			RestorePrevious = 6206664339066247152uL,
			EnablePhysics = 1538342485506640358uL,
			DisablePhysics = 4359553660366836495uL
		}

		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public PhysicsEnableActionType ActionOnBegin { get; set; }

		public PhysicsEnableActionType ActionOnEnd { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, ActionOnBegin);
			BaseProperty.SerializePropertyEnum(output, endianess, ActionOnEnd);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			ActionOnBegin = BaseProperty.DeserializePropertyEnum<PhysicsEnableActionType>(input, endianess);
			ActionOnEnd = BaseProperty.DeserializePropertyEnum<PhysicsEnableActionType>(input, endianess);
		}
	}
}
