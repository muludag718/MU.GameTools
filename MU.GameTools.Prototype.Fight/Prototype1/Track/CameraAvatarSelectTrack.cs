using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.CameraAvatarSelect)]
	public class CameraAvatarSelectTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public CameraType CameraType { get; set; }

		public bool Parent { get; set; }

		public ulong GrabSlot { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, CameraType);
			output.WriteValueB32(Parent, endianess);
			output.WriteValueU64(GrabSlot, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			CameraType = BaseProperty.DeserializePropertyEnum<CameraType>(input, endianess);
			Parent = input.ReadValueB32(endianess);
			GrabSlot = input.ReadValueU64(endianess);
		}
	}
}
