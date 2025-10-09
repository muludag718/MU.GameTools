using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;
using MU.GameTools.Prototype.Fight.Property;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.OnEvent)]
	public class OnEventTrack : P1Track
	{
		public float BeginTime { get; set; }

		public float EndTime { get; set; }

		public float HookTime { get; set; }

		public int EventMask { get; set; }

		public bool InitialTest { get; set; }

		public BranchReference BranchRef { get; set; } = new BranchReference();

		public int Priority { get; set; }

		public PropertyConditionGroup Conditions { get; set; } = new PropertyConditionGroup(PropertyHash.Conditions);

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(BeginTime, endianess);
			output.WriteValueF32(EndTime, endianess);
			output.WriteValueF32(HookTime, endianess);
			output.WriteValueS32(EventMask);
			output.WriteValueB32(InitialTest, endianess);
			BranchRef.Serialize(output, endianess);
			output.WriteValueS32(Priority, endianess);
		}

		public override void SerializeProperties(PrototypeGame game, Stream output, Endian endianess)
		{
			BaseProperty.SerializeBaseProperty(PrototypeGame.P1, output, endianess, Conditions);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			BeginTime = input.ReadValueF32(endianess);
			EndTime = input.ReadValueF32(endianess);
			HookTime = input.ReadValueF32(endianess);
			EventMask = input.ReadValueS32(endianess);
			InitialTest = input.ReadValueB32(endianess);
			BranchRef = new BranchReference(input, endianess);
			Priority = input.ReadValueS32(endianess);
		}

		public override void DeserializeProperties(PrototypeGame game, Stream input, Endian endianess)
		{
			Conditions = BaseProperty.DeserializeConditionProperty(PrototypeGame.P1, input, endianess, PropertyHash.Conditions);
		}
	}
}
