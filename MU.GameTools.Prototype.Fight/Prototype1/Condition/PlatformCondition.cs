using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Condition
{
	[KnownCondition(ConditionHash.Platform)]
	public class PlatformCondition : P1Condition
	{
		public bool PS2 { get; set; }

		public bool XBox { get; set; }

		public bool GameCube { get; set; }

		public bool Win32 { get; set; }

		public bool Xenon { get; set; }

		public bool PS3 { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueB32(PS2, endianess);
			output.WriteValueB32(XBox, endianess);
			output.WriteValueB32(GameCube, endianess);
			output.WriteValueB32(Win32, endianess);
			output.WriteValueB32(Xenon, endianess);
			output.WriteValueB32(PS3, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			PS2 = input.ReadValueB32(endianess);
			XBox = input.ReadValueB32(endianess);
			GameCube = input.ReadValueB32(endianess);
			Win32 = input.ReadValueB32(endianess);
			Xenon = input.ReadValueB32(endianess);
			PS3 = input.ReadValueB32(endianess);
		}
	}
}
