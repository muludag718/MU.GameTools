using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.AllowGrabbing)]
	public class AllowGrabbingTrack : P1Track
	{
		public enum GrabStart : ulong
		{
			DoNothing = 16252691783617167704uL,
			Allow = 4586725638409169159uL,
			Forbid = 9905570320066967050uL
		}

		public enum GrabEnd : ulong
		{
			Restore = 8128040577595920368uL,
			Allow = 4586725638409169159uL,
			Forbid = 9905570320066967050uL
		}

		public float BeginTime { get; set; }

		public float EndTime { get; set; }

		public GrabStart OnBegin { get; set; }

		public GrabEnd OnEnd { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(BeginTime, endianess);
			output.WriteValueF32(EndTime, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, OnBegin);
			BaseProperty.SerializePropertyEnum(output, endianess, OnEnd);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			BeginTime = input.ReadValueF32(endianess);
			EndTime = input.ReadValueF32(endianess);
			OnBegin = BaseProperty.DeserializePropertyEnum<GrabStart>(input, endianess);
			OnEnd = BaseProperty.DeserializePropertyEnum<GrabEnd>(input, endianess);
		}
	}
}
