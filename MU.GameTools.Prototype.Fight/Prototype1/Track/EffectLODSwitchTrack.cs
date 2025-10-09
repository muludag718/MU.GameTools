using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;
using MU.GameTools.Prototype.Fight.Property;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.EffectLODSwitch)]
	public class EffectLODSwitchTrack : P1Track
	{
		public float LodStartDistance { get; set; }

		public float LodUpdateRateMilliseconds { get; set; }

		public PropertyTrackGroup Effect { get; set; } = new PropertyTrackGroup(PropertyHash.Effect);

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(LodStartDistance, endianess);
			output.WriteValueF32(LodUpdateRateMilliseconds, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			LodStartDistance = input.ReadValueF32(endianess);
			LodUpdateRateMilliseconds = input.ReadValueF32(endianess);
		}

		public override void SerializeProperties(PrototypeGame game, Stream output, Endian endianess)
		{
			BaseProperty.SerializeBaseProperty(PrototypeGame.P1, output, endianess, Effect);
		}

		public override void DeserializeProperties(PrototypeGame game, Stream input, Endian endianess)
		{
			Effect = BaseProperty.DeserializeTrackProperty(PrototypeGame.P1, input, endianess, PropertyHash.Effect);
		}
	}
}
