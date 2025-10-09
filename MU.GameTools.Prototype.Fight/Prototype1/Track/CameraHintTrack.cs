using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.CameraHint)]
	public class CameraHintTrack : P1Track
	{
		public enum HintType : ulong
		{
			Slide = 5865338372162726487uL,
			Falling = 1546725305262767233uL,
			Running = 13391260477670660353uL,
			Jumping = 6370575284602695520uL,
			Climbing = 5229273973122016849uL,
			WallRun = 7764074208662850059uL,
			Float = 4980286969596303762uL,
			QuickTurn = 2669843167633621244uL,
			HopJump = 11894878010327071993uL,
			Parkour = 13938991474149399574uL,
			Grapple = 4313919289786887845uL,
			RollLeft = 11461592797946620918uL,
			RollRight = 16208179408930410493uL,
			AutoTarget = 4751627266579880038uL,
			Glide = 5015188191654984259uL,
			AirDash = 11955892389761813344uL,
			LockControls = 9256397209407139691uL
		}

		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public HintType Hint { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Hint);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Hint = BaseProperty.DeserializePropertyEnum<HintType>(input, endianess);
		}
	}
}
