using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.LODSteer)]
	public class LODSteerTrack : P1Track
	{
		public enum AnimType : ulong
		{
			PPS_NONE = 17576375266414389028uL,
			PPS_STANDING = 14839415451792732434uL,
			PPS_WALKING = 6640379199237813563uL,
			PPS_RUNNING = 5574202178697275883uL,
			PPS_FLOAT = 16359170657376327024uL,
			PPS_DEAD = 17579198064016454736uL,
			PPS_COWER = 16754144050052644138uL,
			PPS_LOWMORALEWALKING = 14802021181383392899uL,
			PPS_LOWMORALERUNNING = 6384415947139926867uL,
			PPS_LOWMORALESTANDING = 6079132282527946170uL,
			PPS_SPAWN_DEAD = 1598921015234818384uL,
			PPS_RUBBERNECKING = 5362461859085663867uL
		}

		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float Speed { get; set; }

		public AnimType Walk_anim { get; set; }

		public AnimType Idle_anim { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(Speed, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Walk_anim);
			BaseProperty.SerializePropertyEnum(output, endianess, Idle_anim);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Speed = input.ReadValueF32(endianess);
			Walk_anim = BaseProperty.DeserializePropertyEnum<AnimType>(input, endianess);
			Idle_anim = BaseProperty.DeserializePropertyEnum<AnimType>(input, endianess);
		}
	}
}
