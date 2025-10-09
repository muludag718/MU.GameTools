using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.Stun)]
	public class StunTrack : P1Track
	{
		public enum StunActionType : ulong
		{
			DoNothing = 3876518407870578744uL,
			RestoreToPrevious = 6206664339066247152uL,
			Stun = 23429501539295808uL,
			Recover = 97766630827740312uL
		}

		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public StunActionType OnBegin { get; set; }

		public StunActionType OnEnd { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, OnBegin);
			BaseProperty.SerializePropertyEnum(output, endianess, OnEnd);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			OnBegin = BaseProperty.DeserializePropertyEnum<StunActionType>(input, endianess);
			OnEnd = BaseProperty.DeserializePropertyEnum<StunActionType>(input, endianess);
		}
	}
}
