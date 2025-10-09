using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.WorldDamage)]
	public class WorldDamageTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public ulong Joint { get; set; }

		public Vector Position { get; set; } = new Vector();

		public Vector Direction { get; set; } = new Vector();

		public bool UseSupportingLimb { get; set; }

		public float Distance { get; set; }

		public DamageType DamageType { get; set; }

		public AttackType AttackType { get; set; }

		public ulong HitType { get; set; }

		public ulong EffectType { get; set; }

		public float ScaleX { get; set; }

		public float ScaleY { get; set; }

		public float EffectScale { get; set; }

		public float PropAreaEmissionScale { get; set; }

		public ScaleFunction PropAreaEmissionScaleFunction { get; set; }

		public float PropAreaSizeScale { get; set; }

		public ScaleFunction PropAreaSizeScaleFunction { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueU64(Joint, endianess);
			Position.Serialize(output, endianess);
			Direction.Serialize(output, endianess);
			output.WriteValueB32(UseSupportingLimb, endianess);
			output.WriteValueF32(Distance, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, DamageType);
			BaseProperty.SerializePropertyEnum(output, endianess, AttackType);
			output.WriteValueU64(HitType, endianess);
			output.WriteValueU64(EffectType, endianess);
			output.WriteValueF32(ScaleX, endianess);
			output.WriteValueF32(ScaleY, endianess);
			output.WriteValueF32(EffectScale, endianess);
			output.WriteValueF32(PropAreaEmissionScale, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, PropAreaEmissionScaleFunction);
			output.WriteValueF32(PropAreaSizeScale, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, PropAreaSizeScaleFunction);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			Joint = input.ReadValueU64(endianess);
			Position = new Vector(input, endianess);
			Direction = new Vector(input, endianess);
			UseSupportingLimb = input.ReadValueB32(endianess);
			Distance = input.ReadValueF32(endianess);
			DamageType = BaseProperty.DeserializePropertyEnum<DamageType>(input, endianess);
			AttackType = BaseProperty.DeserializePropertyEnum<AttackType>(input, endianess);
			HitType = input.ReadValueU64(endianess);
			EffectType = input.ReadValueU64(endianess);
			ScaleX = input.ReadValueF32(endianess);
			ScaleY = input.ReadValueF32(endianess);
			EffectScale = input.ReadValueF32(endianess);
			PropAreaEmissionScale = input.ReadValueF32(endianess);
			PropAreaEmissionScaleFunction = BaseProperty.DeserializePropertyEnum<ScaleFunction>(input, endianess);
			PropAreaSizeScale = input.ReadValueF32(endianess);
			PropAreaSizeScaleFunction = BaseProperty.DeserializePropertyEnum<ScaleFunction>(input, endianess);
		}
	}
}
