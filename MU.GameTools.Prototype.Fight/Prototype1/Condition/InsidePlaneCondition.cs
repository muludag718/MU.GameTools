using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.InsidePlane)]
	public class InsidePlaneCondition : P1Condition
	{
		public ulong GrabSlot { get; set; }

		public ulong Joint { get; set; }

		public bool Inside { get; set; }

		public Vector Offset { get; set; } = new Vector();

		public Vector Orientation { get; set; } = new Vector();

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueU64(GrabSlot, endianess);
			output.WriteValueU64(Joint, endianess);
			output.WriteValueB32(Inside, endianess);
			Offset.Serialize(output, endianess);
			Orientation.Serialize(output, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			GrabSlot = input.ReadValueU64(endianess);
			Joint = input.ReadValueU64(endianess);
			Inside = input.ReadValueB32(endianess);
			Offset.Deserialize(input, endianess);
			Orientation.Deserialize(input, endianess);
		}
	}
}
