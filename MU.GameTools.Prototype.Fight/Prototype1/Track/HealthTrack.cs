using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.Health)]
	public class HealthTrack : P1Track
	{
		public enum ApplyToHealhType : ulong
		{
			CurrentHealth = 14120912836564576008uL,
			PercentageCurrentHealth = 5073460416179252554uL,
			PercentageMaximumHealth = 11308088312728993153uL
		}

		public float TimeBegin { get; set; }

		public OperationType Operation { get; set; }

		public ApplyToHealhType ApplyTo { get; set; }

		public float Health { get; set; }

		public bool ChangeMaxHealth { get; set; }

		public bool ChangeMinHealth { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Operation);
			BaseProperty.SerializePropertyEnum(output, endianess, ApplyTo);
			output.WriteValueF32(Health, endianess);
			output.WriteValueB32(ChangeMaxHealth, endianess);
			output.WriteValueB32(ChangeMinHealth, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			Operation = BaseProperty.DeserializePropertyEnum<OperationType>(input, endianess);
			ApplyTo = BaseProperty.DeserializePropertyEnum<ApplyToHealhType>(input, endianess);
			Health = input.ReadValueF32(endianess);
			ChangeMaxHealth = input.ReadValueB32(endianess);
			ChangeMinHealth = input.ReadValueB32(endianess);
		}
	}
}
