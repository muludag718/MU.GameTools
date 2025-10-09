using System;
using System.Collections.Generic;
using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;
using MU.GameTools.Prototype.Fight.Prototype1;
using MU.GameTools.Prototype.Fight.Prototype2;

namespace MU.GameTools.Prototype.Fight
{
	public abstract class BaseTrack : FightNode
	{
		public BaseTrack()
		{
			KnownTrackAttribute knownTrackAttribute = (KnownTrackAttribute)GetType().GetCustomAttributes(typeof(KnownTrackAttribute), inherit: false)[0];
			base.TypeHash = knownTrackAttribute.Hash;
		}

		public override object Clone(PrototypeGame game)
		{
			Stream stream = new MemoryStream();
			SerializeBaseTrack(game, stream, Endian.Little, this);
			stream.Position = 0L;
			ulong hash = stream.ReadValueU64();
			return DeserializeBaseTrack(game, stream, Endian.Little, hash);
		}

		public static void SerializeBaseTrack(PrototypeGame game, Stream output, Endian endianess, BaseTrack track)
		{
			switch (game)
			{
			case PrototypeGame.P1:
				P1Track.SerializeBaseTrack(output, endianess, track);
				break;
			case PrototypeGame.P2:
				P2Track.SerializeBaseTrack(output, endianess, track);
				break;
			default:
				throw new Exception("Non valid game");
			}
		}

		public static void SerializeBaseTracks(PrototypeGame game, Stream output, Endian endianess, List<BaseTrack> tracks)
		{
			switch (game)
			{
			case PrototypeGame.P1:
				P1Track.SerializeBaseTracks(output, endianess, tracks);
				break;
			case PrototypeGame.P2:
				P2Track.SerializeBaseTracks(output, endianess, tracks);
				break;
			default:
				throw new Exception("Non valid game");
			}
		}

		public static BaseTrack DeserializeBaseTrack(PrototypeGame game, Stream input, Endian endianess, ulong hash)
		{
			return game switch
			{
				PrototypeGame.P1 => P1Track.DeserializeBaseTrack(input, endianess, hash), 
				PrototypeGame.P2 => P2Track.DeserializeBaseTrack(input, endianess, hash), 
				_ => throw new Exception("Non valid game"), 
			};
		}

		public static List<BaseTrack> DeserializeBaseTracks(PrototypeGame game, Stream input, Endian endianess)
		{
			return game switch
			{
				PrototypeGame.P1 => P1Track.DeserializeBaseTracks(input, endianess), 
				PrototypeGame.P2 => P2Track.DeserializeBaseTracks(input, endianess), 
				_ => throw new Exception("Non valid game"), 
			};
		}
	}
}
