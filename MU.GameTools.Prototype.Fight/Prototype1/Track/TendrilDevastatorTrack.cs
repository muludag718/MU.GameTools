using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.TendrilDevastator)]
	public class TendrilDevastatorTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float Distance { get; set; }

		public BranchReference TargetBranch { get; set; } = new BranchReference();

		public int TendrilCount { get; set; }

		public float AttackTimeBegin { get; set; }

		public float AttackTimeDuration { get; set; }

		public AttackType AttackType { get; set; }

		public float AttackDamage { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(Distance, endianess);
			TargetBranch.Serialize(output, endianess);
			output.WriteValueS32(TendrilCount, endianess);
			output.WriteValueF32(AttackTimeBegin, endianess);
			output.WriteValueF32(AttackTimeDuration, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, AttackType);
			output.WriteValueF32(AttackDamage, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Distance = input.ReadValueF32(endianess);
			TargetBranch = new BranchReference(input, endianess);
			TendrilCount = input.ReadValueS32(endianess);
			AttackTimeBegin = input.ReadValueF32(endianess);
			AttackTimeDuration = input.ReadValueF32(endianess);
			AttackType = BaseProperty.DeserializePropertyEnum<AttackType>(input, endianess);
			AttackDamage = input.ReadValueF32(endianess);
		}
	}
}
