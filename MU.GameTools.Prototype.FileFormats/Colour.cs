using System.IO;
using System.Runtime.Serialization;
using MU.GameTools.IO;

namespace MU.GameTools.Prototype.FileFormats
{
	[DataContract(Namespace = "http://datacontract.gib.me/prototype")]
	public class Colour
	{
		[DataMember(Name = "r", Order = 1)]
		public float R { get; set; }

		[DataMember(Name = "g", Order = 2)]
		public float G { get; set; }

		[DataMember(Name = "b", Order = 3)]
		public float B { get; set; }

		[DataMember(Name = "a", Order = 4)]
		public float A { get; set; }

		public void Serialize(Stream output)
		{
			output.WriteValueF32(R);
			output.WriteValueF32(G);
			output.WriteValueF32(B);
			output.WriteValueF32(A);
		}

		public void Deserialize(Stream input)
		{
			R = input.ReadValueF32();
			G = input.ReadValueF32();
			B = input.ReadValueF32();
			A = input.ReadValueF32();
		}
	}
}
