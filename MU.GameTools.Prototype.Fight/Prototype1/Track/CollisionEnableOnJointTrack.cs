using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.CollisionEnableOnJoint)]
	public class CollisionEnableOnJointTrack : P1Track
	{
		public enum OnBeginType : ulong
		{
			DoNothing = 3876518407870578744uL,
			EnableCollision = 12870800434117538617uL,
			DisableCollision = 16309147254971539904uL
		}

		public enum OnEndType : ulong
		{
			DoNothing = 3876518407870578744uL,
			RestoreToPrevious = 6206664339066247152uL,
			EnableCollision = 12870800434117538617uL,
			DisableCollision = 16309147254971539904uL
		}

		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public ulong SimulatedJoint { get; set; }

		public OnBeginType ActionOnBegin { get; set; }

		public OnEndType ActionOnEnd { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueU64(SimulatedJoint, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, ActionOnBegin);
			BaseProperty.SerializePropertyEnum(output, endianess, ActionOnEnd);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			SimulatedJoint = input.ReadValueU64(endianess);
			ActionOnBegin = BaseProperty.DeserializePropertyEnum<OnBeginType>(input, endianess);
			ActionOnEnd = BaseProperty.DeserializePropertyEnum<OnEndType>(input, endianess);
		}
	}
}
