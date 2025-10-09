using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.TargetGoTo)]
	public class TargetGoToTrack : P1Track
	{
		public enum WhereType : ulong
		{
			Target = 856854631462190855uL,
			GrabTarget = 1754404701201221985uL
		}

		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public WhereType Where { get; set; }

		public float Tolerance { get; set; }

		public float ToleranceRePathfind { get; set; }

		public float MinTimeBetweenPathfind { get; set; }

		public bool UseRandomOvershoot { get; set; }

		public float RandomOvershootLowerBound { get; set; }

		public float RandomOvershootUpperBound { get; set; }

		public bool Brake { get; set; }

		public bool IgnoreRestrictions { get; set; }

		public bool StayOnGround { get; set; }

		public bool ProjectPositionToGround { get; set; }

		public bool TargetClimbing { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Where);
			output.WriteValueF32(Tolerance, endianess);
			output.WriteValueF32(ToleranceRePathfind, endianess);
			output.WriteValueF32(MinTimeBetweenPathfind, endianess);
			output.WriteValueB32(UseRandomOvershoot, endianess);
			output.WriteValueF32(RandomOvershootLowerBound, endianess);
			output.WriteValueF32(RandomOvershootUpperBound, endianess);
			output.WriteValueB32(Brake, endianess);
			output.WriteValueB32(IgnoreRestrictions, endianess);
			output.WriteValueB32(StayOnGround, endianess);
			output.WriteValueB32(ProjectPositionToGround, endianess);
			output.WriteValueB32(TargetClimbing, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Where = BaseProperty.DeserializePropertyEnum<WhereType>(input, endianess);
			Tolerance = input.ReadValueF32(endianess);
			ToleranceRePathfind = input.ReadValueF32(endianess);
			MinTimeBetweenPathfind = input.ReadValueF32(endianess);
			UseRandomOvershoot = input.ReadValueB32(endianess);
			RandomOvershootLowerBound = input.ReadValueF32(endianess);
			RandomOvershootUpperBound = input.ReadValueF32(endianess);
			Brake = input.ReadValueB32(endianess);
			IgnoreRestrictions = input.ReadValueB32(endianess);
			StayOnGround = input.ReadValueB32(endianess);
			ProjectPositionToGround = input.ReadValueB32(endianess);
			TargetClimbing = input.ReadValueB32(endianess);
		}
	}
}
