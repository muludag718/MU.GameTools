using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.ManageLifetime)]
	public class ManageLifetimeTrack : P1Track
	{
		public float TimeBegin { get; set; }

		public bool ManageLifetime { get; set; }

		public bool AttachedToParent { get; set; }

		public ulong GrabSlot { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueB32(ManageLifetime, endianess);
			output.WriteValueB32(AttachedToParent, endianess);
			output.WriteValueU64(GrabSlot, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			ManageLifetime = input.ReadValueB32(endianess);
			AttachedToParent = input.ReadValueB32(endianess);
			GrabSlot = input.ReadValueU64(endianess);
		}
	}
}
