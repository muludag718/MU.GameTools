using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;
using MU.GameTools.Prototype.Fight.Property;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.EdgeDetect)]
	public class EdgeDetectTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float SurfaceOffset { get; set; }

		public float LookaheadDistance { get; set; }

		public float EdgeDepth { get; set; }

		public Vector CardinalVector { get; set; } = new Vector();

		public float LookaheadDistanceNonCardinal { get; set; }

		public BranchReference Branch { get; set; } = new BranchReference();

		public int Priority { get; set; }

		public PropertyConditionGroup Conditions { get; set; } = new PropertyConditionGroup(PropertyHash.Conditions);

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(SurfaceOffset, endianess);
			output.WriteValueF32(LookaheadDistance, endianess);
			output.WriteValueF32(EdgeDepth, endianess);
			CardinalVector.Serialize(output, endianess);
			output.WriteValueF32(LookaheadDistanceNonCardinal, endianess);
			Branch.Serialize(output, endianess);
			output.WriteValueS32(Priority, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			SurfaceOffset = input.ReadValueF32(endianess);
			LookaheadDistance = input.ReadValueF32(endianess);
			EdgeDepth = input.ReadValueF32(endianess);
			CardinalVector = new Vector(input, endianess);
			LookaheadDistanceNonCardinal = input.ReadValueF32(endianess);
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
