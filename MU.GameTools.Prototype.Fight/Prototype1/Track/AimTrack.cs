using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.AI)]
	[KnownTrack(TrackHash.Aim)]
	public class AimTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public LookAtTarget Where { get; set; }

		public Vector Offset { get; set; } = new Vector();

		public bool ForceWorldAngles { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Where);
			Offset.Serialize(output, endianess);
			output.WriteValueB32(ForceWorldAngles, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Where = BaseProperty.DeserializePropertyEnum<LookAtTarget>(input, endianess);
			Offset = new Vector(input, endianess);
			ForceWorldAngles = input.ReadValueB32(endianess);
		}
	}
}
