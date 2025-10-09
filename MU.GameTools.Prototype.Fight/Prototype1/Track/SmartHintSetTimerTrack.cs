using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownNodeForContext(ContextHash.Motion)]
	[KnownTrack(TrackHash.SmartHintSetTimer)]
	public class SmartHintSetTimerTrack : P1Track
	{
		public enum TimerType : ulong
		{
			Sprint = 139431196041208856uL,
			WallRun = 7764074208662850059uL,
			Target = 856854631462190855uL,
			Special = 14665729337295026497uL,
			Attack = 17648781240126830036uL,
			ThrowObject = 10411039871081615289uL,
			CameraStick = 12012351502380158027uL,
			CameraReset = 12121494932376928046uL,
			Combo = 4729075459507432078uL,
			AttackCharged = 9166767161979886648uL,
			JumpCharged = 12737234338093086820uL,
			JumpChargedSprinting = 680685272192896404uL,
			JumpMulti = 2163982626737384203uL,
			CameraResetInTank = 6622348168307747967uL,
			Consume = 1055741811302362110uL,
			EPRemind = 738561241418108496uL,
			PowerUnused = 2129866768912735281uL,
			ThermalVisionUnused = 1638144665266917203uL,
			AirDash = 11955892389761813344uL,
			WOINeglected = 14745935532602829756uL,
			GlideRemind = 9189042604311415864uL,
			StartMission = 4351880290315119674uL,
			WeaponGrab = 18395871681580613670uL,
			Devastator = 16626996011609549067uL
		}

		public TimerType Timer { get; set; }

		public float Value { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Timer);
			output.WriteValueF32(Value, endianess);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			Timer = BaseProperty.DeserializePropertyEnum<TimerType>(input, endianess);
			Value = input.ReadValueF32(endianess);
		}
	}
}
