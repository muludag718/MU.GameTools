using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.Teleport)]
	public class TeleportTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public bool RestorePosition { get; set; }

		public ulong Object { get; set; }

		public SpaceType Space { get; set; }

		public ulong SpaceJoint { get; set; }

		public Vector Offset { get; set; } = new Vector();

		public Vector Orientation { get; set; } = new Vector();

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueB32(RestorePosition, endianess);
			output.WriteValueU64(Object, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Space);
			output.WriteValueU64(SpaceJoint, endianess);
			Offset.Serialize(output, endianess);
			Orientation.Serialize(output, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			RestorePosition = input.ReadValueB32(endianess);
			Object = input.ReadValueU64(endianess);
			Space = BaseProperty.DeserializePropertyEnum<SpaceType>(input, endianess);
			SpaceJoint = input.ReadValueU64(endianess);
			Offset.Deserialize(input, endianess);
			Orientation.Deserialize(input, endianess);
		}
	}
}
