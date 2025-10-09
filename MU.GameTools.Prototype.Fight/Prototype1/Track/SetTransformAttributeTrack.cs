using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.SetTransformAttribute)]
	public class SetTransformAttributeTrack : P1Track
	{
		public Vector Transform { get; set; } = new Vector();

		public Vector RotationEulerAnglesXYZ { get; set; } = new Vector();

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			Transform.Serialize(output, endianess);
			RotationEulerAnglesXYZ.Serialize(output, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Transform.Deserialize(input, endianess);
			RotationEulerAnglesXYZ.Deserialize(input, endianess);
		}
	}
}
