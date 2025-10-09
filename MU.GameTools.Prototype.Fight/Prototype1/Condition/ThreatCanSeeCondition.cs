using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownCondition(ConditionHash.ThreatCanSee)]
	public class ThreatCanSeeCondition : P1Condition
	{
		public ulong Name { get; set; }

		public float FOV { get; set; }

		public Vector Direction { get; set; } = new Vector();

		public bool IgnoreY { get; set; }

		public bool GiversPerspective { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueU64(Name, endianess);
			output.WriteValueF32(FOV, endianess);
			Direction.Serialize(output, endianess);
			output.WriteValueB32(IgnoreY, endianess);
			output.WriteValueB32(GiversPerspective, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Name = input.ReadValueU64(endianess);
			FOV = input.ReadValueF32(endianess);
			Direction.Deserialize(input, endianess);
			IgnoreY = input.ReadValueB32(endianess);
			GiversPerspective = input.ReadValueB32(endianess);
		}
	}
}
