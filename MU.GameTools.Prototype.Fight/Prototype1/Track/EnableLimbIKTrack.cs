using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.EnableLimbIK)]
	public class EnableLimbIKTrack : P1Track
	{
		public enum LimbIKOnBeginAction : ulong
		{
			DoNothing = 3876518407870578744uL,
			EnableLimbIK = 8673583303231311789uL,
			DisableLimbIK = 12982675630842063176uL
		}

		public enum LimbIKOnEndAction : ulong
		{
			RestorePrevious = 6206664339066247152uL,
			EnableLimbIK = 8673583303231311789uL,
			DisableLimbIK = 12982675630842063176uL
		}

		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public LimbIKOnBeginAction ActionOnBegin { get; set; }

		public LimbIKOnEndAction ActionOnEnd { get; set; }

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
			ActionOnBegin = BaseProperty.DeserializePropertyEnum<LimbIKOnBeginAction>(input, endianess);
			ActionOnEnd = BaseProperty.DeserializePropertyEnum<LimbIKOnEndAction>(input, endianess);
		}
	}
}
