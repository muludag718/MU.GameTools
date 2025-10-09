using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.PedestrianState)]
	public class PedestrianStateCondition : P1Condition
	{
		public enum PedestrianStateType : ulong
		{
			PedestrianState_Walking = 18075099910908824922uL,
			PedestrianState_Running = 15550110210725836214uL,
			PedestrianState_Crosswalk_Walking = 14570086209907466100uL,
			PedestrianState_Crosswalk_Running = 2630255935707042220uL,
			PedestrianState_Panicked = 16961301976731947450uL,
			PedestrianState_InfectedAreaPanicked = 14471925035603885565uL,
			PedestrianState_Cowering = 3424767917318801581uL,
			PedestrianState_InfectedAreaCowering = 9292131652635289306uL,
			PedestrianState_Standing = 8131735889933293097uL,
			PedestrianState_AtRedLight = 17885541790587772205uL,
			PedestrianState_Blocked = 10269630828599918459uL,
			PedestrianState_Dead = 18390712503526155491uL,
			PedestrianState_SpawnDead = 9421079735691181128uL,
			PedestrianState_PhysicsSimulated = 4477934107992374178uL,
			PedestrianState_Rubbernecking1 = 6499267149839634035uL,
			PedestrianState_Rubbernecking2 = 6499267149839634032uL,
			PedestrianState_JogAvoid = 1711324512440749982uL
		}

		public bool Match { get; set; }

		public PedestrianStateType State { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueB32(Match, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, State);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Match = input.ReadValueB32(endianess);
			State = BaseProperty.DeserializePropertyEnum<PedestrianStateType>(input, endianess);
		}
	}
}
