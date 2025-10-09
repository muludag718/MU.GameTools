using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.VelocityLinear)]
	public class VelocityLinearTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public OperationType Operation { get; set; }

		public Vector LinearVelocity { get; set; } = new Vector();

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Operation);
			LinearVelocity.Serialize(output, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			Operation = BaseProperty.DeserializePropertyEnum<OperationType>(input, endianess);
			LinearVelocity = new Vector(input, endianess);
		}
	}
}
