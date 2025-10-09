using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.HitReaction)]
	public class HitReactionTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float ReactionTimeMin { get; set; }

		public float ReactionTimeMax { get; set; }

		public float ReactionDistanceMin { get; set; }

		public float ReactionDistanceMax { get; set; }

		public float ReactionHeightMin { get; set; }

		public float ReactionHeightMax { get; set; }

		public Vector ReactionDirection { get; set; } = new Vector();

		public AttackType AttackType { get; set; }

		public ulong HitType { get; set; }

		public DamageType DamageType { get; set; }

		public ulong CollisionFlag { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(ReactionTimeMin, endianess);
			output.WriteValueF32(ReactionTimeMax, endianess);
			output.WriteValueF32(ReactionDistanceMin, endianess);
			output.WriteValueF32(ReactionDistanceMax, endianess);
			output.WriteValueF32(ReactionHeightMin, endianess);
			output.WriteValueF32(ReactionHeightMax, endianess);
			ReactionDirection.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, AttackType);
			output.WriteValueU64(HitType, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, DamageType);
			output.WriteValueU64(CollisionFlag, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			ReactionTimeMin = input.ReadValueF32(endianess);
			ReactionTimeMax = input.ReadValueF32(endianess);
			ReactionDistanceMin = input.ReadValueF32(endianess);
			ReactionDistanceMax = input.ReadValueF32(endianess);
			ReactionHeightMin = input.ReadValueF32(endianess);
			ReactionHeightMax = input.ReadValueF32(endianess);
			ReactionDirection = new Vector(input, endianess);
			AttackType = BaseProperty.DeserializePropertyEnum<AttackType>(input, endianess);
			HitType = input.ReadValueU64(endianess);
			DamageType = BaseProperty.DeserializePropertyEnum<DamageType>(input, endianess);
			CollisionFlag = input.ReadValueU64(endianess);
		}
	}
}
