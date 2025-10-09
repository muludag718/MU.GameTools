using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;
using MU.GameTools.Prototype.Fight.Property;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.ReactionHitExecute)]
	public class ReactionHitExecuteTrack : P1Track
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

		public float ExtraDamage { get; set; }

		public bool UseOriginator { get; set; }

		public bool SendAlert { get; set; }

		public AttackType AttackType { get; set; }

		public ulong HitType { get; set; }

		public DamageType DamageType { get; set; }

		public ulong CollisionFlag { get; set; }

		public BranchReference Branch { get; set; } = new BranchReference();

		public PropertyConditionGroup Conditions { get; set; } = new PropertyConditionGroup(PropertyHash.Conditions);

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
			output.WriteValueF32(ExtraDamage, endianess);
			output.WriteValueB32(UseOriginator, endianess);
			output.WriteValueB32(SendAlert, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, AttackType);
			output.WriteValueU64(HitType, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, DamageType);
			output.WriteValueU64(CollisionFlag, endianess);
			Branch.Serialize(output, endianess);
		}

		public override void SerializeProperties(PrototypeGame game, Stream output, Endian endianess)
		{
			BaseProperty.SerializeBaseProperty(PrototypeGame.P1, output, endianess, Conditions);
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
			ExtraDamage = input.ReadValueF32(endianess);
			UseOriginator = input.ReadValueB32(endianess);
			SendAlert = input.ReadValueB32(endianess);
			AttackType = BaseProperty.DeserializePropertyEnum<AttackType>(input, endianess);
			HitType = input.ReadValueU64(endianess);
			DamageType = BaseProperty.DeserializePropertyEnum<DamageType>(input, endianess);
			CollisionFlag = input.ReadValueU64(endianess);
			Branch = new BranchReference(input, endianess);
		}

		public override void DeserializeProperties(PrototypeGame game, Stream input, Endian endianess)
		{
			Conditions = BaseProperty.DeserializeConditionProperty(PrototypeGame.P1, input, endianess, PropertyHash.Conditions);
		}
	}
}
