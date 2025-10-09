using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.SetSecondaryWeaponType)]
	public class SetSecondaryWeaponTypeTrack : P1Track
	{
		public enum SecondaryWeaponType : ulong
		{
			Gun50mm = 13590193798748521041uL,
			Rocket = 14395127206582377560uL,
			Missile = 13148182856864364872uL,
			Bloodtox = 18124356316935178433uL
		}

		public float TimeBegin { get; set; }

		public SecondaryWeaponType Type { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Type);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			Type = BaseProperty.DeserializePropertyEnum<SecondaryWeaponType>(input, endianess);
		}
	}
}
