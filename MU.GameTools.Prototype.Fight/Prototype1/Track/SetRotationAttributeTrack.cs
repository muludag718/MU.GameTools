using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.SetRotationAttribute)]
	public class SetRotationAttributeTrack : P1Track
	{
		public Vector RotationAxis { get; set; } = new Vector();

		public float RotationDegrees { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			RotationAxis.Serialize(output, endianess);
			output.WriteValueF32(RotationDegrees, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			RotationAxis.Deserialize(input, endianess);
			RotationDegrees = input.ReadValueF32(endianess);
		}
	}
}
