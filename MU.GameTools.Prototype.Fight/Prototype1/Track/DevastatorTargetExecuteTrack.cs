using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.DevastatorTargetExecute)]
	public class DevastatorTargetExecuteTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public bool UseAttackTimeBegin { get; set; }

		public bool UseAttackTimeEnd { get; set; }

		public bool SetTarget { get; set; }

		public BranchReference ReceiverBranch { get; set; } = new BranchReference();

		public int InterruptPriority { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueB32(UseAttackTimeBegin, endianess);
			output.WriteValueB32(UseAttackTimeEnd, endianess);
			output.WriteValueB32(SetTarget, endianess);
			ReceiverBranch.Serialize(output, endianess);
			output.WriteValueS32(InterruptPriority, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			UseAttackTimeBegin = input.ReadValueB32(endianess);
			UseAttackTimeEnd = input.ReadValueB32(endianess);
			SetTarget = input.ReadValueB32(endianess);
			ReceiverBranch = new BranchReference(input, endianess);
			InterruptPriority = input.ReadValueS32(endianess);
		}
	}
}
