using System;
using System.Collections.Generic;
using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;
using MU.GameTools.Prototype.Fight.Prototype1;
using MU.GameTools.Prototype.Fight.Prototype2;

namespace MU.GameTools.Prototype.Fight
{
	public abstract class BaseCondition : FightNode
	{
		public BaseCondition()
		{
			KnownConditionAttribute knownConditionAttribute = (KnownConditionAttribute)GetType().GetCustomAttributes(typeof(KnownConditionAttribute), inherit: false)[0];
			base.TypeHash = knownConditionAttribute.Hash;
		}

		public override object Clone(PrototypeGame game)
		{
			Stream stream = new MemoryStream();
			SerializeBaseCondition(game, stream, Endian.Little, this);
			stream.Position = 0L;
			ulong hash = stream.ReadValueU64();
			return DeserializeBaseCondition(game, stream, Endian.Little, hash);
		}

		public static void SerializeBaseCondition(PrototypeGame game, Stream output, Endian endianess, BaseCondition condition)
		{
			switch (game)
			{
			case PrototypeGame.P1:
				P1Condition.SerializeBaseCondition(output, endianess, condition);
				break;
			case PrototypeGame.P2:
				P2Condition.SerializeBaseCondition(output, endianess, condition);
				break;
			default:
				throw new Exception("Non valid game");
			}
		}

		public static void SerializeBaseConditions(PrototypeGame game, Stream output, Endian endianess, List<BaseCondition> conditions)
		{
			switch (game)
			{
			case PrototypeGame.P1:
				P1Condition.SerializeBaseConditions(output, endianess, conditions);
				break;
			case PrototypeGame.P2:
				P2Condition.SerializeBaseConditions(output, endianess, conditions);
				break;
			default:
				throw new Exception("Non valid game");
			}
		}

		public static BaseCondition DeserializeBaseCondition(PrototypeGame game, Stream input, Endian endianess, ulong hash)
		{
			return game switch
			{
				PrototypeGame.P1 => P1Condition.DeserializeBaseCondition(input, endianess, hash), 
				PrototypeGame.P2 => P2Condition.DeserializeBaseCondition(input, endianess, hash), 
				_ => throw new Exception("Non valid game"), 
			};
		}

		public static List<BaseCondition> DeserializeBaseConditions(PrototypeGame game, Stream input, Endian endianess)
		{
			return game switch
			{
				PrototypeGame.P1 => P1Condition.DeserializeBaseConditions(input, endianess), 
				PrototypeGame.P2 => P2Condition.DeserializeBaseConditions(input, endianess), 
				_ => throw new Exception("Non valid game"), 
			};
		}
	}
}
