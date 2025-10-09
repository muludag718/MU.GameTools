using System.IO;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.Fight.Prototype1.Track
{
	[KnownTrack(TrackHash.RequestToken)]
	public class RequestTokenTrack : P1Track
	{
		public enum RequestTokenType : ulong
		{
			Hunter = 6865395180375055270uL,
			FireClearRequest = 7926183158331532086uL
		}

		public float TimeBegin { get; set; }

		public float TimeEnd { get; set; }

		public RequestTokenType Type { get; set; }

		public override void Serialize(Stream output, Endian endianess)
		{
			base.Serialize(output, endianess);
			output.WriteValueF32(TimeBegin, endianess);
			output.WriteValueF32(TimeEnd, endianess);
			BaseProperty.SerializePropertyEnum(output, endianess, Type);
		}

		public override void Deserialize(Stream input, Endian endianess)
		{
			base.Deserialize(input, endianess);
			TimeBegin = input.ReadValueF32(endianess);
			TimeEnd = input.ReadValueF32(endianess);
			Type = BaseProperty.DeserializePropertyEnum<RequestTokenType>(input, endianess);
		}
	}
}
