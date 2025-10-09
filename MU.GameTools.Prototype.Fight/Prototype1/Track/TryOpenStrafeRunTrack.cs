using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;
using MU.GameTools.Prototype.Fight.Property;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.TryOpenStrafeRun)]
	public class TryOpenStrafeRunTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float MaxHeightPath { get; set; }

		public float MaxHeightEnd { get; set; }

		public float MinHeightWithTarget { get; set; }

		public float EndHigherThanTarget { get; set; }

		public float MaxHeightStartWithTarget { get; set; }

		public float MinHeightStartWithTarget { get; set; }

		public int MaxLength { get; set; }

		public int MinLength { get; set; }

		public int MinLengthAfterTarget { get; set; }

		public float MinLengthBeforeTarget { get; set; }

		public float MaxHeightToIgnoreStartLength { get; set; }

		public float FreeRadiusStart { get; set; }

		public float FreeRadiusPath { get; set; }

		public float FreeRadiusEnd { get; set; }

		public BranchReference IfFound { get; set; } = new BranchReference();

		public int Priority { get; set; }

		public PropertyConditionGroup Conditions { get; set; } = new PropertyConditionGroup(PropertyHash.Conditions);

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(MaxHeightPath, endianess);
			output.WriteValueF32(MaxHeightEnd, endianess);
			output.WriteValueF32(MinHeightWithTarget, endianess);
			output.WriteValueF32(EndHigherThanTarget, endianess);
			output.WriteValueF32(MaxHeightStartWithTarget, endianess);
			output.WriteValueF32(MinHeightStartWithTarget, endianess);
			output.WriteValueS32(MaxLength, endianess);
			output.WriteValueS32(MinLength, endianess);
			output.WriteValueS32(MinLengthAfterTarget, endianess);
			output.WriteValueF32(MinLengthBeforeTarget, endianess);
			output.WriteValueF32(MaxHeightToIgnoreStartLength, endianess);
			output.WriteValueF32(FreeRadiusStart, endianess);
			output.WriteValueF32(FreeRadiusPath, endianess);
			output.WriteValueF32(FreeRadiusEnd, endianess);
			IfFound.Serialize(output, endianess);
			output.WriteValueS32(Priority, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			MaxHeightPath = input.ReadValueF32(endianess);
			MaxHeightEnd = input.ReadValueF32(endianess);
			MinHeightWithTarget = input.ReadValueF32(endianess);
			EndHigherThanTarget = input.ReadValueF32(endianess);
			MaxHeightStartWithTarget = input.ReadValueF32(endianess);
			MinHeightStartWithTarget = input.ReadValueF32(endianess);
			MaxLength = input.ReadValueS32(endianess);
			MinLength = input.ReadValueS32(endianess);
			MinLengthAfterTarget = input.ReadValueS32(endianess);
			MinLengthBeforeTarget = input.ReadValueF32(endianess);
			MaxHeightToIgnoreStartLength = input.ReadValueF32(endianess);
			FreeRadiusStart = input.ReadValueF32(endianess);
			FreeRadiusPath = input.ReadValueF32(endianess);
			FreeRadiusEnd = input.ReadValueF32(endianess);
			IfFound.Deserialize(input, endianess);
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
