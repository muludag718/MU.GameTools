using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;
using MU.GameTools.Prototype.Fight.Property;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.TrackGroup)]
	public class TrackGroupTrack : P1Track
	{
		public ulong GroupName { get; set; }

		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public PropertyConditionGroup Conditions { get; set; } = new PropertyConditionGroup(PropertyHash.Conditions);

		public PropertyTrackGroup Tracks { get; set; } = new PropertyTrackGroup(PropertyHash.Tracks);

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueU64(GroupName, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
		}

		public override void SerializeProperties(PrototypeGame game, Stream output, Endian endianess)
		{
			BaseProperty.SerializeBaseProperty(PrototypeGame.P1, output, endianess, Conditions);
			BaseProperty.SerializeBaseProperty(PrototypeGame.P1, output, endianess, Tracks);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			GroupName = input.ReadValueU64(endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
		}

		public override void DeserializeProperties(PrototypeGame game, Stream input, Endian endianess)
		{
			Conditions = BaseProperty.DeserializeConditionProperty(PrototypeGame.P1, input, endianess, PropertyHash.Conditions);
			Tracks = BaseProperty.DeserializeTrackProperty(PrototypeGame.P1, input, endianess, PropertyHash.Tracks);
		}
	}
}
