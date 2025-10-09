using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;
using MU.GameTools.Prototype.Fight.Property;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.ObstacleTest)]
	public class ObstacleTestTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float LookaheadDistance { get; set; }

		public float CharacterHeight { get; set; }

		public float CharacterWidth { get; set; }

		public float CharacterDepth { get; set; }

		public float CharacterSurfaceClearance { get; set; }

		public float ObstacleHeightMin { get; set; }

		public float ObstacleHeightMax { get; set; }

		public float ObstacleLengthMax { get; set; }

		public Vector SurfaceNormalOverride { get; set; } = new Vector();

		public float PoleAvoidVelocity { get; set; }

		public BranchReference Branch { get; set; } = new BranchReference();

		public int Priority { get; set; }

		public PropertyConditionGroup Conditions { get; set; } = new PropertyConditionGroup(PropertyHash.Conditions);

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(LookaheadDistance, endianess);
			output.WriteValueF32(CharacterHeight, endianess);
			output.WriteValueF32(CharacterWidth, endianess);
			output.WriteValueF32(CharacterDepth, endianess);
			output.WriteValueF32(CharacterSurfaceClearance, endianess);
			output.WriteValueF32(ObstacleHeightMin, endianess);
			output.WriteValueF32(ObstacleHeightMax, endianess);
			output.WriteValueF32(ObstacleLengthMax, endianess);
			SurfaceNormalOverride.Serialize(output, endianess);
			output.WriteValueF32(PoleAvoidVelocity, endianess);
			Branch.Serialize(output, endianess);
			output.WriteValueS32(Priority, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			LookaheadDistance = input.ReadValueF32(endianess);
			CharacterHeight = input.ReadValueF32(endianess);
			CharacterWidth = input.ReadValueF32(endianess);
			CharacterDepth = input.ReadValueF32(endianess);
			CharacterSurfaceClearance = input.ReadValueF32(endianess);
			ObstacleHeightMin = input.ReadValueF32(endianess);
			ObstacleHeightMax = input.ReadValueF32(endianess);
			ObstacleLengthMax = input.ReadValueF32(endianess);
			SurfaceNormalOverride = new Vector(input, endianess);
			PoleAvoidVelocity = input.ReadValueF32(endianess);
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
