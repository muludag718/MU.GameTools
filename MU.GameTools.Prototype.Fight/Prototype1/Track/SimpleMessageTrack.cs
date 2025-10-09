using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.SimpleMessage)]
	public class SimpleMessageTrack : P1Track
	{
		public enum MessageType : ulong
		{
			None = 22018610510307286uL,
			Reset = 5832977143813391573uL,
			ShowDebug = 6867926323523701038uL,
			HideDebug = 14783914829641130149uL,
			StartAnimation = 10120730374998231438uL,
			StopAnimation = 9047650238404902018uL,
			ForceQueryTree = 5275318950478620811uL
		}

		public float TimeBegin { get; set; }

		public MessageType Message { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Message);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			Message = BaseProperty.DeserializePropertyEnum<MessageType>(input, endianess);
		}
	}
}
