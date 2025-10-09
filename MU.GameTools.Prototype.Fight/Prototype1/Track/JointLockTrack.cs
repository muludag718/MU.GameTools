using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.JointLock)]
	public class JointLockTrack : P1Track
	{
		public enum TranslationLockType : ulong
		{
			All = 279702787393uL,
			Y = 89uL,
			XZ = 5772786uL,
			None = 22018610510307286uL
		}

		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public ulong LockedJoint { get; set; }

		public TranslationLockType TranslationLock { get; set; }

		public Vector OffsetTranslation { get; set; } = new Vector();

		public Vector OffsetOrientation { get; set; } = new Vector();

		public bool AutoUpdate { get; set; }

		public int Priority { get; set; }

		public float BlendInTime { get; set; }

		public float BlendOutTime { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			output.WriteValueU64(LockedJoint, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, TranslationLock);
			OffsetTranslation.Serialize(output, endianess);
			OffsetOrientation.Serialize(output, endianess);
			output.WriteValueB32(AutoUpdate, endianess);
			output.WriteValueS32(Priority, endianess);
			output.WriteValueF32(BlendInTime, endianess);
			output.WriteValueF32(BlendOutTime, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			LockedJoint = input.ReadValueU64(endianess);
			TranslationLock = BaseProperty.DeserializePropertyEnum<TranslationLockType>(input, endianess);
			OffsetTranslation.Deserialize(input, endianess);
			OffsetOrientation.Deserialize(input, endianess);
			AutoUpdate = input.ReadValueB32(endianess);
			Priority = input.ReadValueS32(endianess);
			BlendInTime = input.ReadValueF32(endianess);
			BlendOutTime = input.ReadValueF32(endianess);
		}
	}
}
