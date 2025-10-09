using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;
using MU.GameTools.Prototype.Fight.Property;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.AI)]
	[KnownTrack(TrackHash.OnCollision)]
	public class OnCollisionTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public ColliderType CollideWith { get; set; }

		public float ImpulseThreshold { get; set; }

		public BranchReference Branch { get; set; } = new BranchReference();

		public int Priority { get; set; }

		public PropertyConditionGroup Conditions { get; set; } = new PropertyConditionGroup(PropertyHash.Conditions);

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			BaseProperty.SerializePropertyBitfield(output, endianess, CollideWith);
			output.WriteValueF32(ImpulseThreshold, endianess);
			Branch.Serialize(output, endianess);
			output.WriteValueS32(Priority, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			CollideWith = BaseProperty.DeserializePropertyBitfield<ColliderType>(input, endianess);
			ImpulseThreshold = input.ReadValueF32(endianess);
			Branch = new BranchReference(input, endianess);
			Priority = input.ReadValueS32(endianess);
		}

		public override void SerializeProperties(PrototypeGame game, Stream output, Endian endianess)
		{
			BaseProperty.SerializeBaseProperty(PrototypeGame.P1, output, endianess, Conditions);
		}

		public override void DeserializeProperties(PrototypeGame game, Stream input, Endian endianess)
		{
			Conditions = BaseProperty.DeserializeConditionProperty(PrototypeGame.P1, input, endianess, PropertyHash.Conditions);
		}
	}
}
