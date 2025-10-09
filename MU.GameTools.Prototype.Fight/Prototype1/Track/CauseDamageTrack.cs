using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.CauseDamage)]
	public class CauseDamageTrack : P1Track
	{
		public enum DamageOriginatorType : ulong
		{
			HitOriginator = 10079825596818229623uL,
			GameObject = 16917872325796917431uL,
			GrabSlot = 7882620167033900854uL,
			ParentGameObject = 14378065813107577471uL,
			Player = 12290011226446443607uL
		}

		public float BeginTime { get; set; }

		public bool ForceZeroHealth { get; set; }

		public float Damage { get; set; }

		public AttackType AttackType { get; set; }

		public DamageOriginatorType Originator { get; set; }

		public ulong GrabSlotName { get; set; }

		public bool IgnoreShield { get; set; }

		public bool SendAlert { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(BeginTime, endianess);
			output.WriteValueB32(ForceZeroHealth, endianess);
			output.WriteValueF32(Damage, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, AttackType);
			BaseProperty.SerializePropertyEnum(output, endianess, Originator);
			output.WriteValueU64(GrabSlotName, endianess);
			output.WriteValueB32(IgnoreShield, endianess);
			output.WriteValueB32(SendAlert, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			BeginTime = input.ReadValueF32(endianess);
			ForceZeroHealth = input.ReadValueB32(endianess);
			Damage = input.ReadValueF32(endianess);
			AttackType = BaseProperty.DeserializePropertyEnum<AttackType>(input, endianess);
			Originator = BaseProperty.DeserializePropertyEnum<DamageOriginatorType>(input, endianess);
			GrabSlotName = input.ReadValueU64(endianess);
			IgnoreShield = input.ReadValueB32(endianess);
			SendAlert = input.ReadValueB32(endianess);
		}
	}
}
