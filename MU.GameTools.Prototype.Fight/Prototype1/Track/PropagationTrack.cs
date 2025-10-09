using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.Propagation)]
	public class PropagationTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float MaxDeflection { get; set; }

		public bool EnableDirection { get; set; }

		public Vector Direction { get; set; } = new Vector();

		public float Distance { get; set; }

		public float DamagePercentage { get; set; }

		public DamageType DamageType { get; set; }

		public AttackType AttackType { get; set; }

		public ulong HitType { get; set; }

		public ulong EffectType { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(MaxDeflection, endianess);
			output.WriteValueB32(EnableDirection, endianess);
			Direction.Serialize(output, endianess);
			output.WriteValueF32(Distance, endianess);
			output.WriteValueF32(DamagePercentage, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, DamageType);
			BaseProperty.SerializePropertyEnum(output, endianess, AttackType);
			output.WriteValueU64(HitType, endianess);
			output.WriteValueU64(EffectType, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			MaxDeflection = input.ReadValueF32(endianess);
			EnableDirection = input.ReadValueB32(endianess);
			Direction.Deserialize(input, endianess);
			Distance = input.ReadValueF32(endianess);
			DamagePercentage = input.ReadValueF32(endianess);
			DamageType = BaseProperty.DeserializePropertyEnum<DamageType>(input, endianess);
			AttackType = BaseProperty.DeserializePropertyEnum<AttackType>(input, endianess);
			HitType = input.ReadValueU64(endianess);
			EffectType = input.ReadValueU64(endianess);
		}
	}
}
