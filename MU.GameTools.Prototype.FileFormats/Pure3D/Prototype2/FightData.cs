using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;
using MU.GameTools.Prototype.Fight;

namespace MU.GameTools.Prototype.FileFormats.Pure3D.Prototype2
{
	[KnownGame(PrototypeGame.P2)]
	public class FightData : BaseNode
	{
		private FightFile fightFile;

		public override bool Exportable => true;

		public override void Serialize(Stream output, Endian endian)
		{
			fightFile.SerializeFig(PrototypeGame.P2, output, endian);
		}

		public override void Deserialize(Stream input, Endian endian)
		{
			fightFile = new FightFile();
			fightFile.DeserializeFig(PrototypeGame.P2, input, endian);
		}

		public override void Export(Stream output)
		{
		}
	}
}
