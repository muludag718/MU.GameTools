using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.VelocityAngular)]
	public class VelocityAngularTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public CompareOperator Operation { get; set; }

		public Vector AngularVelocity { get; set; } = new Vector();

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Operation);
			AngularVelocity.Serialize(output, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			Operation = BaseProperty.DeserializePropertyEnum<CompareOperator>(input, endianess);
			AngularVelocity.Deserialize(input, endianess);
		}
	}
}
