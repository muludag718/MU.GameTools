using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Scenario)]
	[KnownTrack(TrackHash.StateMachineStart)]
	public class StateMachineStartTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public ulong Name { get; set; }

		public string Args { get; set; }

		public string Tags { get; set; }

		public string Channel { get; set; }

		public BranchReference StateMachineBranchRef { get; set; } = new BranchReference();

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueU64(Name, endianess);
			output.WriteStringU32(Args, endianess);
			output.WriteStringU32(Tags, endianess);
			output.WriteStringU32(Channel, endianess);
			StateMachineBranchRef.Serialize(output, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Name = input.ReadValueU64(endianess);
			Args = input.ReadStringAlignedU32(endianess);
			Tags = input.ReadStringAlignedU32(endianess);
			Channel = input.ReadStringAlignedU32(endianess);
			StateMachineBranchRef = new BranchReference(input, endianess);
		}
	}
}
