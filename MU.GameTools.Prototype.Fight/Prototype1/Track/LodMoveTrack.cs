using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.LODMove)]
	public class LodMoveTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public LODStateType Walk_anim { get; set; }

		public LODStateType Idle_anim { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Walk_anim);
			BaseProperty.SerializePropertyEnum(output, endianess, Idle_anim);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Walk_anim = BaseProperty.DeserializePropertyEnum<LODStateType>(input, endianess);
			Idle_anim = BaseProperty.DeserializePropertyEnum<LODStateType>(input, endianess);
		}
	}
}
