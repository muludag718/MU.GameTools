using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.AttachObject)]
	public class AttachObjectTrack : P1Track
	{
		public enum CharacterModeType : ulong
		{
			Unsupported = 5579534211636476125uL,
			Supported = 13080926986062682178uL,
			Locomoting = 16331038302739447885uL
		}

		public float TimeBegin { get; set; }

		public float BlendDuration { get; set; }

		public ulong ParentName { get; set; }

		public ulong ParentJointName { get; set; }

		public Vector ParentOffset { get; set; } = new Vector();

		public ulong ObjectToAttach { get; set; }

		public ulong ChildJointName { get; set; }

		public Vector ChildOffset { get; set; } = new Vector();

		public Vector ChildOrientation { get; set; } = new Vector();

		public bool UsePhysics { get; set; }

		public PhysicsMode ModeIfUsingPhysics { get; set; }

		public CharacterModeType CharacterModeIfSimulated { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(BlendDuration, endianess);
			output.WriteValueU64(ParentName, endianess);
			output.WriteValueU64(ParentJointName, endianess);
			ParentOffset.Serialize(output, endianess);
			output.WriteValueU64(ObjectToAttach, endianess);
			output.WriteValueU64(ChildJointName, endianess);
			ChildOffset.Serialize(output, endianess);
			ChildOrientation.Serialize(output, endianess);
			output.WriteValueB32(UsePhysics, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, ModeIfUsingPhysics);
			BaseProperty.SerializePropertyEnum(output, endianess, CharacterModeIfSimulated);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			BlendDuration = input.ReadValueF32(endianess);
			ParentName = input.ReadValueU64(endianess);
			ParentJointName = input.ReadValueU64(endianess);
			ParentOffset.Deserialize(input, endianess);
			ObjectToAttach = input.ReadValueU64(endianess);
			ChildJointName = input.ReadValueU64(endianess);
			ChildOffset.Deserialize(input, endianess);
			ChildOrientation.Deserialize(input, endianess);
			UsePhysics = input.ReadValueB32(endianess);
			ModeIfUsingPhysics = BaseProperty.DeserializePropertyEnum<PhysicsMode>(input, endianess);
			CharacterModeIfSimulated = BaseProperty.DeserializePropertyEnum<CharacterModeType>(input, endianess);
		}
	}
}
