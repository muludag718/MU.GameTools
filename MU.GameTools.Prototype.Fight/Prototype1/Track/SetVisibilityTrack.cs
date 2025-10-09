using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.SetVisibility)]
	public class SetVisibilityTrack : P1Track
	{
		public enum VisibilityAction : ulong
		{
			Hide = 20324808014569680uL,
			Show = 23429415473539035uL,
			DoNothingOnEnd = 16390556839076977012uL
		}

		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public VisibilityAction ActionOnBegin { get; set; }

		public VisibilityAction ActionOnEnd { get; set; }

		public bool ApplyToGrabSlots { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, ActionOnBegin);
			BaseProperty.SerializePropertyEnum(output, endianess, ActionOnEnd);
			output.WriteValueB32(ApplyToGrabSlots, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			ActionOnBegin = BaseProperty.DeserializePropertyEnum<VisibilityAction>(input, endianess);
			ActionOnEnd = BaseProperty.DeserializePropertyEnum<VisibilityAction>(input, endianess);
			ApplyToGrabSlots = input.ReadValueB32(endianess);
		}
	}
}
