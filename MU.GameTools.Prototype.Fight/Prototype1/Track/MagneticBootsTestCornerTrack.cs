using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;
using MU.GameTools.Prototype.Fight.Property;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.MagneticBootsTestCorner)]
	public class MagneticBootsTestCornerTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float LookAhead { get; set; }

		public float CornerDepth { get; set; }

		public float CornerLookBack { get; set; }

		public ColliderType CollideWith { get; set; }

		public bool DebugDraw { get; set; }

		public BranchReference Branch { get; set; } = new BranchReference();

		public int Priority { get; set; }

		public PropertyConditionGroup Conditions { get; set; } = new PropertyConditionGroup(PropertyHash.Conditions);

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(LookAhead, endianess);
			output.WriteValueF32(CornerDepth, endianess);
			output.WriteValueF32(CornerLookBack, endianess);
			BaseProperty.SerializePropertyBitfield(output, endianess, CollideWith);
			output.WriteValueB32(DebugDraw, endianess);
			Branch.Serialize(output, endianess);
			output.WriteValueS32(Priority, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			LookAhead = input.ReadValueF32(endianess);
			CornerDepth = input.ReadValueF32(endianess);
			CornerLookBack = input.ReadValueF32(endianess);
			CollideWith = BaseProperty.DeserializePropertyBitfield<ColliderType>(input, endianess);
			DebugDraw = input.ReadValueB32(endianess);
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
