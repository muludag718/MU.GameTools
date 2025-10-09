using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.TemporaryTargetable)]
	public class TemporaryTargetableTrack : P1Track
	{
		public enum OnEventType : ulong
		{
			DontChange = 7513540739177987366uL,
			Targetable = 686235301512787779uL,
			NonTargetable = 15836497568040073772uL,
			Restore = 17405989608029490314uL
		}

		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public OnEventType OnBegin { get; set; }

		public OnEventType OnEnd { get; set; }

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
			OnBegin = BaseProperty.DeserializePropertyEnum<OnEventType>(input, endianess);
			OnEnd = BaseProperty.DeserializePropertyEnum<OnEventType>(input, endianess);
		}
	}
}
