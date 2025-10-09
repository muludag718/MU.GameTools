using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.ShootAutoTarget)]
	public class ShootAutoTargetTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public float Arc { get; set; }

		public float MaxDistance { get; set; }

		public bool UseSecondCone { get; set; }

		public float Arc2 { get; set; }

		public float MaxDistance2 { get; set; }

		public TargetClass MinPriorityTargetClass { get; set; }

		public TargetClass MaxPriorityTargetClass { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueF32(Arc, endianess);
			output.WriteValueF32(MaxDistance, endianess);
			output.WriteValueB32(UseSecondCone, endianess);
			output.WriteValueF32(Arc2, endianess);
			output.WriteValueF32(MaxDistance2, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, MinPriorityTargetClass);
			BaseProperty.SerializePropertyEnum(output, endianess, MaxPriorityTargetClass);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Arc = input.ReadValueF32(endianess);
			MaxDistance = input.ReadValueF32(endianess);
			UseSecondCone = input.ReadValueB32(endianess);
			Arc2 = input.ReadValueF32(endianess);
			MaxDistance2 = input.ReadValueF32(endianess);
			MinPriorityTargetClass = BaseProperty.DeserializePropertyEnum<TargetClass>(input, endianess);
			MaxPriorityTargetClass = BaseProperty.DeserializePropertyEnum<TargetClass>(input, endianess);
		}
	}
}
