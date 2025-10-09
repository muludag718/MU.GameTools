using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.WorldConeDamage)]
	public class WorldConeDamageTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public Vector Position { get; set; } = new Vector();

		public Vector Direction { get; set; } = new Vector();

		public Vector Up { get; set; } = new Vector();

		public float MinAngle { get; set; }

		public float MaxAngle { get; set; }

		public float StartDistance { get; set; }

		public float Length { get; set; }

		public int MinDecals { get; set; }

		public int MaxDecals { get; set; }

		public float MinDecalScale { get; set; }

		public float MaxDecalScale { get; set; }

		public DamageType DamageType { get; set; }

		public AttackType AttackType { get; set; }

		public ulong HitType { get; set; }

		public ulong EffectType { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			Position.Serialize(output, endianess);
			Direction.Serialize(output, endianess);
			Up.Serialize(output, endianess);
			output.WriteValueF32(MinAngle, endianess);
			output.WriteValueF32(MaxAngle, endianess);
			output.WriteValueF32(StartDistance, endianess);
			output.WriteValueF32(Length, endianess);
			output.WriteValueS32(MinDecals, endianess);
			output.WriteValueS32(MaxDecals, endianess);
			output.WriteValueF32(MinDecalScale, endianess);
			output.WriteValueF32(MaxDecalScale, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, DamageType);
			BaseProperty.SerializePropertyEnum(output, endianess, AttackType);
			output.WriteValueU64(HitType, endianess);
			output.WriteValueU64(EffectType, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			Position.Deserialize(input, endianess);
			Direction.Deserialize(input, endianess);
			Up.Deserialize(input, endianess);
			MinAngle = input.ReadValueF32(endianess);
			MaxAngle = input.ReadValueF32(endianess);
			StartDistance = input.ReadValueF32(endianess);
			Length = input.ReadValueF32(endianess);
			MinDecals = input.ReadValueS32(endianess);
			MaxDecals = input.ReadValueS32(endianess);
			MinDecalScale = input.ReadValueF32(endianess);
			MaxDecalScale = input.ReadValueF32(endianess);
			DamageType = BaseProperty.DeserializePropertyEnum<DamageType>(input, endianess);
			AttackType = BaseProperty.DeserializePropertyEnum<AttackType>(input, endianess);
			HitType = input.ReadValueU64(endianess);
			EffectType = input.ReadValueU64(endianess);
		}
	}
}
