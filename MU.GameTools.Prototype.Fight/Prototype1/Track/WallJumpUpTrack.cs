using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.WallJumpUp)]
	public class WallJumpUpTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float FlightTimeMin { get; set; }

		public float FlightTimeMax { get; set; }

		public float HeightMin { get; set; }

		public float HeightMax { get; set; }

		public float TurnVelocityMin { get; set; }

		public float TurnVelocityMax { get; set; }

		public float TurnAccelerationMin { get; set; }

		public float TurnAccelerationMax { get; set; }

		public UnlockableEnum UnlockableFirst { get; set; }

		public UnlockableEnum UnlockableLast { get; set; }

		public float UnlockableFlightTimeMin { get; set; }

		public float UnlockableHeightMin { get; set; }

		public float ObstacleLookaheadDistance { get; set; }

		public float CharacterHeight { get; set; }

		public float CharacterWidth { get; set; }

		public float CharacterDepth { get; set; }

		public float CharacterSurfaceClearance { get; set; }

		public float ObstacleHeightMin { get; set; }

		public float ObstacleHeightMax { get; set; }

		public float ObstacleLengthMax { get; set; }

		public float PushOutHeightMin { get; set; }

		public float PushOutVelocityMax { get; set; }

		public float ObstacleFaceHeightMin { get; set; }

		public float PushOutHeightMax { get; set; }

		public float ObstacleSlopeMax { get; set; }

		public float AbortRayLength { get; set; }

		public int Priority { get; set; }

		public float BlendInTime { get; set; }

		public float BlendOutTime { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(FlightTimeMin, endianess);
			output.WriteValueF32(FlightTimeMax, endianess);
			output.WriteValueF32(HeightMin, endianess);
			output.WriteValueF32(HeightMax, endianess);
			output.WriteValueF32(TurnVelocityMin, endianess);
			output.WriteValueF32(TurnVelocityMax, endianess);
			output.WriteValueF32(TurnAccelerationMin, endianess);
			output.WriteValueF32(TurnAccelerationMax, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, UnlockableFirst);
			BaseProperty.SerializePropertyEnum(output, endianess, UnlockableLast);
			output.WriteValueF32(UnlockableFlightTimeMin, endianess);
			output.WriteValueF32(UnlockableHeightMin, endianess);
			output.WriteValueF32(ObstacleLookaheadDistance, endianess);
			output.WriteValueF32(CharacterHeight, endianess);
			output.WriteValueF32(CharacterWidth, endianess);
			output.WriteValueF32(CharacterDepth, endianess);
			output.WriteValueF32(CharacterSurfaceClearance, endianess);
			output.WriteValueF32(ObstacleHeightMin, endianess);
			output.WriteValueF32(ObstacleHeightMax, endianess);
			output.WriteValueF32(ObstacleLengthMax, endianess);
			output.WriteValueF32(PushOutHeightMin, endianess);
			output.WriteValueF32(PushOutVelocityMax, endianess);
			output.WriteValueF32(ObstacleFaceHeightMin, endianess);
			output.WriteValueF32(PushOutHeightMax, endianess);
			output.WriteValueF32(ObstacleSlopeMax, endianess);
			output.WriteValueF32(AbortRayLength, endianess);
			output.WriteValueS32(Priority, endianess);
			output.WriteValueF32(BlendInTime, endianess);
			output.WriteValueF32(BlendOutTime, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			FlightTimeMin = input.ReadValueF32(endianess);
			FlightTimeMax = input.ReadValueF32(endianess);
			HeightMin = input.ReadValueF32(endianess);
			HeightMax = input.ReadValueF32(endianess);
			TurnVelocityMin = input.ReadValueF32(endianess);
			TurnVelocityMax = input.ReadValueF32(endianess);
			TurnAccelerationMin = input.ReadValueF32(endianess);
			TurnAccelerationMax = input.ReadValueF32(endianess);
			UnlockableFirst = BaseProperty.DeserializePropertyEnum<UnlockableEnum>(input, endianess);
			UnlockableLast = BaseProperty.DeserializePropertyEnum<UnlockableEnum>(input, endianess);
			UnlockableFlightTimeMin = input.ReadValueF32(endianess);
			UnlockableHeightMin = input.ReadValueF32(endianess);
			ObstacleLookaheadDistance = input.ReadValueF32(endianess);
			CharacterHeight = input.ReadValueF32(endianess);
			CharacterWidth = input.ReadValueF32(endianess);
			CharacterDepth = input.ReadValueF32(endianess);
			CharacterSurfaceClearance = input.ReadValueF32(endianess);
			ObstacleHeightMin = input.ReadValueF32(endianess);
			ObstacleHeightMax = input.ReadValueF32(endianess);
			ObstacleLengthMax = input.ReadValueF32(endianess);
			PushOutHeightMin = input.ReadValueF32(endianess);
			PushOutVelocityMax = input.ReadValueF32(endianess);
			ObstacleFaceHeightMin = input.ReadValueF32(endianess);
			PushOutHeightMax = input.ReadValueF32(endianess);
			ObstacleSlopeMax = input.ReadValueF32(endianess);
			AbortRayLength = input.ReadValueF32(endianess);
			Priority = input.ReadValueS32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
		}
	}
}
