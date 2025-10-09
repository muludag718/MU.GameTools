using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Scenario)]
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.Sound)]
	public class SoundTrack : P1Track
	{
		public enum SoundTriggerType : ulong
		{
			Retrigger = 13522664087197083521uL,
			Overlap = 10712345420671996437uL,
			StopExisting = 6266415434618234495uL,
			IgnoreIfPlaying = 3427415984850077271uL
		}

		public float TimeBegin { get; set; }

		public ulong Patch { get; set; }

		public ulong Trigger { get; set; }

		public float VolumeFactor { get; set; }

		public float MinDistance { get; set; }

		public float MaxDistance { get; set; }

		public float MinPitch { get; set; }

		public float MaxPitch { get; set; }

		public float CyclicPhase { get; set; }

		public ulong InstanceName { get; set; }

		public float Frequency { get; set; }

		public bool PolledLifetime { get; set; }

		public SoundTriggerType TriggerType { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueU64(Patch, endianess);
			output.WriteValueU64(Trigger, endianess);
			output.WriteValueF32(VolumeFactor, endianess);
			output.WriteValueF32(MinDistance, endianess);
			output.WriteValueF32(MaxDistance, endianess);
			output.WriteValueF32(MinPitch, endianess);
			output.WriteValueF32(MaxPitch, endianess);
			output.WriteValueF32(CyclicPhase, endianess);
			output.WriteValueU64(InstanceName, endianess);
			output.WriteValueF32(Frequency, endianess);
			output.WriteValueB32(PolledLifetime, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, TriggerType);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			Patch = input.ReadValueU64(endianess);
			Trigger = input.ReadValueU64(endianess);
			VolumeFactor = input.ReadValueF32(endianess);
			MinDistance = input.ReadValueF32(endianess);
			MaxDistance = input.ReadValueF32(endianess);
			MinPitch = input.ReadValueF32(endianess);
			MaxPitch = input.ReadValueF32(endianess);
			CyclicPhase = input.ReadValueF32(endianess);
			InstanceName = input.ReadValueU64(endianess);
			Frequency = input.ReadValueF32(endianess);
			PolledLifetime = input.ReadValueB32(endianess);
			TriggerType = BaseProperty.DeserializePropertyEnum<SoundTriggerType>(input, endianess);
		}
	}
}
