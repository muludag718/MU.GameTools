using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.CameraTypeSelect)]
	public class CameraTypeSelectTrack : P1Track
	{
		public float BeginTime { get; set; }

		public CameraType CameraType { get; set; }

		public float CameraBlendTime { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(BeginTime, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, CameraType);
			output.WriteValueF32(CameraBlendTime, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			BeginTime = input.ReadValueF32(endianess);
			CameraType = BaseProperty.DeserializePropertyEnum<CameraType>(input, endianess);
			CameraBlendTime = input.ReadValueF32(endianess);
		}
	}
}
