using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.EnableLODPatrol)]
	public class EnableLODPatrolTrack : P1Track
	{
		public enum EventPatrolType : ulong
		{
			DoNothing = 3876518407870578744uL,
			RestorePrevious = 6206664339066247152uL,
			EnablePatrol = 5855201438174134505uL,
			DisablePatrol = 3863038993445046482uL
		}

		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public EventPatrolType ActionOnBegin { get; set; }

		public EventPatrolType ActionOnEnd { get; set; }

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
			ActionOnBegin = BaseProperty.DeserializePropertyEnum<EventPatrolType>(input, endianess);
			ActionOnEnd = BaseProperty.DeserializePropertyEnum<EventPatrolType>(input, endianess);
		}
	}
}
