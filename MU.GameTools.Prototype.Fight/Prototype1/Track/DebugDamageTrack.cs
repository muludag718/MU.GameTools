using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.DebugDamage)]
	public class DebugDamageTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float Distance { get; set; }

		public DamageType DamageType { get; set; }

		public float ScaleX { get; set; }

		public float ScaleY { get; set; }

		public ulong DamageSource { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(Distance, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, DamageType);
			output.WriteValueF32(ScaleX, endianess);
			output.WriteValueF32(ScaleY, endianess);
			output.WriteValueU64(DamageSource, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			Distance = input.ReadValueF32(endianess);
			DamageType = BaseProperty.DeserializePropertyEnum<DamageType>(input, endianess);
			ScaleX = input.ReadValueF32(endianess);
			ScaleY = input.ReadValueF32(endianess);
			DamageSource = input.ReadValueU64(endianess);
		}
	}
}
