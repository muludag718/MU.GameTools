using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.GameObjectOrient)]
	public class GameObjectOrientTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float MaxTurnYaw { get; set; }

		public float MaxTurnPitch { get; set; }

		public bool Yaw { get; set; }

		public bool Pitch { get; set; }

		public bool ResetIfNotSetting { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(MaxTurnYaw, endianess);
			output.WriteValueF32(MaxTurnPitch, endianess);
			output.WriteValueB32(Yaw, endianess);
			output.WriteValueB32(Pitch, endianess);
			output.WriteValueB32(ResetIfNotSetting, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			MaxTurnYaw = input.ReadValueF32(endianess);
			MaxTurnPitch = input.ReadValueF32(endianess);
			Yaw = input.ReadValueB32(endianess);
			Pitch = input.ReadValueB32(endianess);
			ResetIfNotSetting = input.ReadValueB32(endianess);
		}
	}
}
