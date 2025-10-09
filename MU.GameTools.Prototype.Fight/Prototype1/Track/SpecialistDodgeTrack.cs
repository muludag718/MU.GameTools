using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;
using MU.GameTools.Prototype.Fight.Property;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.SpecialistDodge)]
	public class SpecialistDodgeTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float MoveBegin { get; set; }

		public float MoveEnd { get; set; }

		public float MoveDistance { get; set; }

		public int Priority { get; set; }

		public float BlendInTime { get; set; }

		public float BlendOutTime { get; set; }

		public float DistanceToAttractorWeight { get; set; }

		public float MaxDistanceToAttractor { get; set; }

		public PropertyTrackGroup LeftAnim { get; set; } = new PropertyTrackGroup(PropertyHash.LeftAnim);

		public PropertyTrackGroup RightAnim { get; set; } = new PropertyTrackGroup(PropertyHash.RightAnim);

		public PropertyTrackGroup BackAnim { get; set; } = new PropertyTrackGroup(PropertyHash.BackAnim);

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(MoveBegin, endianess);
			output.WriteValueF32(MoveEnd, endianess);
			output.WriteValueF32(MoveDistance, endianess);
			output.WriteValueS32(Priority, endianess);
			output.WriteValueF32(BlendInTime, endianess);
			output.WriteValueF32(BlendOutTime, endianess);
			output.WriteValueF32(DistanceToAttractorWeight, endianess);
			output.WriteValueF32(MaxDistanceToAttractor, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			MoveBegin = input.ReadValueF32(endianess);
			MoveEnd = input.ReadValueF32(endianess);
			MoveDistance = input.ReadValueF32(endianess);
			Priority = input.ReadValueS32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
			DistanceToAttractorWeight = input.ReadValueF32(endianess);
			MaxDistanceToAttractor = input.ReadValueF32(endianess);
		}

		public override void SerializeProperties(PrototypeGame game, Stream output, Endian endianess)
		{
			BaseProperty.SerializeBaseProperty(PrototypeGame.P1, output, endianess, LeftAnim);
			BaseProperty.SerializeBaseProperty(PrototypeGame.P1, output, endianess, RightAnim);
			BaseProperty.SerializeBaseProperty(PrototypeGame.P1, output, endianess, BackAnim);
		}

		public override void DeserializeProperties(PrototypeGame game, Stream input, Endian endianess)
		{
			LeftAnim = BaseProperty.DeserializeTrackProperty(PrototypeGame.P1, input, endianess, PropertyHash.LeftAnim);
			RightAnim = BaseProperty.DeserializeTrackProperty(PrototypeGame.P1, input, endianess, PropertyHash.RightAnim);
			BackAnim = BaseProperty.DeserializeTrackProperty(PrototypeGame.P1, input, endianess, PropertyHash.BackAnim);
		}
	}
}
