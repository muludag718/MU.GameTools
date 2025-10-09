using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.CharacterIK)]
	public class CharacterIKTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public ulong RootJoint { get; set; }

		public ulong MidJoint { get; set; }

		public ulong EndJoint { get; set; }

		public TargetClass TargetType { get; set; }

		public int Priority { get; set; }

		public float BlendInTime { get; set; }

		public float BlendOutTime { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueU64(RootJoint, endianess);
			output.WriteValueU64(MidJoint, endianess);
			output.WriteValueU64(EndJoint, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, TargetType);
			output.WriteValueS32(Priority, endianess);
			output.WriteValueF32(BlendInTime, endianess);
			output.WriteValueF32(BlendOutTime, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			RootJoint = input.ReadValueU64(endianess);
			MidJoint = input.ReadValueU64(endianess);
			EndJoint = input.ReadValueU64(endianess);
			TargetType = BaseProperty.DeserializePropertyEnum<TargetClass>(input, endianess);
			Priority = input.ReadValueS32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
		}
	}
}
