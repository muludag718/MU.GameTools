using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.PatsyCreate)]
	public class PatsyCreateTrack : P1Track
	{
		public enum WhoType : ulong
		{
			Target = 856854631462190855uL,
			AutoTarget = 4751627266579880038uL,
			Holding = 10464599244845980941uL,
			Hit = 309834113563uL,
			Clear = 4728793748633909019uL
		}

		public float TimeBegin { get; set; }

		public WhoType Who { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Who);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			Who = BaseProperty.DeserializePropertyEnum<WhoType>(input, endianess);
		}
	}
}
