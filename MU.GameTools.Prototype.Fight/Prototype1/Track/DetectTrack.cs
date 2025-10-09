using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;
using MU.GameTools.Prototype.Fight.Property;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.Detect)]
	public class DetectTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public ulong Joint { get; set; }

		public Vector Offset { get; set; } = new Vector();

		public float Radius { get; set; }

		public float ArcOffset { get; set; }

		public float ArcRange { get; set; }

		public Collidables CollideWith { get; set; }

		public BranchReference Branch { get; set; } = new BranchReference();

		public int Priority { get; set; }

		public PropertyConditionGroup Conditions { get; set; } = new PropertyConditionGroup(PropertyHash.Conditions);

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueU64(Joint, endianess);
			Offset.Serialize(output, endianess);
			output.WriteValueF32(Radius, endianess);
			output.WriteValueF32(ArcOffset, endianess);
			output.WriteValueF32(ArcRange, endianess);
			BaseProperty.SerializePropertyBitfield(output, endianess, CollideWith);
			Branch.Serialize(output, endianess);
			output.WriteValueS32(Priority, endianess);
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
			Joint = input.ReadValueU64(endianess);
			Offset = new Vector(input, endianess);
			Radius = input.ReadValueF32(endianess);
			ArcOffset = input.ReadValueF32(endianess);
			ArcRange = input.ReadValueF32(endianess);
			CollideWith = BaseProperty.DeserializePropertyBitfield<Collidables>(input, endianess);
			Branch = new BranchReference(input, endianess);
			Priority = input.ReadValueS32(endianess);
		}

		public override void DeserializeProperties(PrototypeGame game, Stream input, Endian endianess)
		{
			Conditions = BaseProperty.DeserializeConditionProperty(PrototypeGame.P1, input, endianess, PropertyHash.Conditions);
		}
	}
}
