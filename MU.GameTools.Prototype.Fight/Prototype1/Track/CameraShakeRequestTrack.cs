using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.CameraShakeRequest)]
	public class CameraShakeRequestTrack : P1Track
	{
		public enum CameraShakeSize : ulong
		{
			Small = 8156211258749108097uL,
			Medium = 17784764271712241149uL,
			Large = 7699058135646415813uL
		}

		public float BeginTime { get; set; }

		public CameraShakeSize Size { get; set; }

		public CameraShakeSize Range { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(BeginTime, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Size);
			BaseProperty.SerializePropertyEnum(output, endianess, Range);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			BeginTime = input.ReadValueF32(endianess);
			Size = BaseProperty.DeserializePropertyEnum<CameraShakeSize>(input, endianess);
			Range = BaseProperty.DeserializePropertyEnum<CameraShakeSize>(input, endianess);
		}
	}
}
