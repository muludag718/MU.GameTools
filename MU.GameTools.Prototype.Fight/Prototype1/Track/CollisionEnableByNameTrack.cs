using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.CollisionEnableByName)]
	public class CollisionEnableByNameTrack : P1Track
	{
		public enum EventType : ulong
		{
			DoNothing = 3876518407870578744uL,
			RestoreToPrevious = 6206664339066247152uL,
			EnableCollision = 12870800434117538617uL,
			DisableCollision = 16309147254971539904uL
		}

		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public ulong CollisionObject { get; set; }

		public EventType ActionOnBegin { get; set; }

		public EventType ActionOnEnd { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueU64(CollisionObject, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, ActionOnBegin);
			BaseProperty.SerializePropertyEnum(output, endianess, ActionOnEnd);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			CollisionObject = input.ReadValueU64(endianess);
			ActionOnBegin = BaseProperty.DeserializePropertyEnum<EventType>(input, endianess);
			ActionOnEnd = BaseProperty.DeserializePropertyEnum<EventType>(input, endianess);
		}
	}
}
