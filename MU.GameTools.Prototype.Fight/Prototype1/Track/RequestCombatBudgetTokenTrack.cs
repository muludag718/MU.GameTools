using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.RequestCombatBudgetToken)]
	public class RequestCombatBudgetTokenTrack : P1Track
	{
		public enum CombatEnumType : ulong
		{
			Bullet = 1071813355822642564uL,
			Rocket = 14395127206582377560uL,
			Explosion = 6119690315119812053uL,
			Gib = 305522356882uL
		}

		public float TimeBegin { get; set; }

		public CombatEnumType CombatType { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, CombatType);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			CombatType = BaseProperty.DeserializePropertyEnum<CombatEnumType>(input, endianess);
		}
	}
}
