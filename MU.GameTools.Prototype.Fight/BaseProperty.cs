using System;
using System.Collections.Generic;
using System.IO;
using MU.GameTools.IO;
using MU.GameTools.Common;
using MU.GameTools.Prototype.Fight.Property;

namespace MU.GameTools.Prototype.Fight
{
	public abstract class BaseProperty : FightNode
	{
		public BaseProperty()
		{
		}

		public BaseProperty(PropertyHash hash)
		{
			base.TypeHash = (ulong)hash;
		}

		public static void SerializePropertyEnum<T>(Stream stream, Endian endianess, T value) where T : Enum
		{
			if (!Enum.IsDefined(typeof(T), value))
			{
				throw new NotImplementedException("Enum not defined");
			}
			object obj = Enum.ToObject(typeof(T), value);
			stream.WriteValueU64((ulong)obj, endianess);
		}

		public static T DeserializePropertyEnum<T>(Stream stream, Endian endianess) where T : Enum
		{
			ulong num = stream.ReadValueU64(endianess);
			if (!Enum.IsDefined(typeof(T), num))
			{
				throw new NotImplementedException("Enum not defined");
			}
			return (T)Enum.ToObject(typeof(T), num);
		}

		public static void SerializePropertyBitfield<T>(Stream stream, Endian endianess, T value) where T : Enum
		{
			ulong value2 = (ulong)Enum.ToObject(typeof(T), value);
			stream.WriteValueU32(Convert.ToUInt32(value2), endianess);
		}

		public static T DeserializePropertyBitfield<T>(Stream stream, Endian endianess) where T : Enum
		{
			ulong value = Convert.ToUInt64(stream.ReadValueU32(endianess));
			return (T)Enum.ToObject(typeof(T), value);
		}

		public static PropertyConditionGroup DeserializeConditionProperty(PrototypeGame game, Stream input, Endian endianess, PropertyHash hash)
		{
			return (PropertyConditionGroup)DeserializeBaseProperty(game, input, endianess, hash, isTrack: false);
		}

		public static List<BaseProperty> DeserializeConditionProperties(PrototypeGame game, Stream input, Endian endianess, PropertyHash target)
		{
			return DeserializeBaseProperties(game, input, endianess, target, isTrack: false);
		}

		public static PropertyTrackGroup DeserializeTrackProperty(PrototypeGame game, Stream input, Endian endianess, PropertyHash hash)
		{
			return (PropertyTrackGroup)DeserializeBaseProperty(game, input, endianess, hash, isTrack: true);
		}

		public static List<BaseProperty> DeserializeTrackProperties(PrototypeGame game, Stream input, Endian endianess, PropertyHash target)
		{
			return DeserializeBaseProperties(game, input, endianess, target, isTrack: true);
		}

		public static void SerializeBaseProperty(PrototypeGame game, Stream output, Endian endianess, BaseProperty property)
		{
			switch (game)
			{
			case PrototypeGame.P1:
				P1_SerializeBaseProperty(output, endianess, property);
				break;
			case PrototypeGame.P2:
				P2_SerializeBaseProperty(output, endianess, property);
				break;
			default:
				throw new Exception("Non valid game");
			}
		}

		public static void SerializeBaseProperties(PrototypeGame game, Stream output, Endian endianess, List<BaseProperty> properties)
		{
			switch (game)
			{
			case PrototypeGame.P1:
				P1_SerializeBaseProperties(output, endianess, properties);
				break;
			case PrototypeGame.P2:
				P2_SerializeBaseProperties(output, endianess, properties);
				break;
			default:
				throw new Exception("Non valid game");
			}
		}

		private static BaseProperty DeserializeBaseProperty(PrototypeGame game, Stream input, Endian endianess, PropertyHash hash, bool isTrack)
		{
			return game switch
			{
				PrototypeGame.P1 => P1_DeserializeBaseProperty(input, endianess, hash, isTrack), 
				PrototypeGame.P2 => P2_DeserializeBaseProperty(input, endianess, hash, isTrack), 
				_ => throw new Exception("Non valid game"), 
			};
		}

		private static List<BaseProperty> DeserializeBaseProperties(PrototypeGame game, Stream input, Endian endianess, PropertyHash target, bool isTrack)
		{
			return game switch
			{
				PrototypeGame.P1 => P1_DeserializeBaseProperties(input, endianess, target, isTrack), 
				PrototypeGame.P2 => P2_DeserializeBaseProperties(input, endianess, target, isTrack), 
				_ => throw new Exception("Non valid game"), 
			};
		}

		private static void P1_SerializeBaseProperty(Stream output, Endian endianess, BaseProperty property)
		{
			output.WriteValueU64(property.TypeHash, endianess);
			Stream stream = new MemoryStream();
			property.Serialize(stream, endianess);
			output.WriteValueU32((uint)stream.Length, endianess);
			stream.Seek(0L, SeekOrigin.Begin);
			output.WriteFromStream(stream, stream.Length);
			property.SerializeProperties(PrototypeGame.P1, output, endianess);
			output.WriteValueU64(0uL);
		}

		private static void P1_SerializeBaseProperties(Stream output, Endian endianess, List<BaseProperty> properties)
		{
			foreach (BaseProperty property in properties)
			{
				P1_SerializeBaseProperty(output, endianess, property);
			}
		}

		private static BaseProperty P1_DeserializeBaseProperty(Stream input, Endian endianess, PropertyHash hash, bool isTrack)
		{
			if (hash != (PropertyHash)input.ReadValueU64(endianess))
			{
				throw new Exception("Read wrong property hash");
			}
			BaseProperty baseProperty = ((!isTrack) ? ((BaseProperty)new PropertyConditionGroup(hash)) : ((BaseProperty)new PropertyTrackGroup(hash)));
			if (baseProperty == null)
			{
				throw new NotImplementedException("Unknown property");
			}
			uint num = input.ReadValueU32(endianess);
			long position = input.Position;
			baseProperty.Deserialize(input, endianess);
			if (input.Position != position + num)
			{
				throw new FormatException("Invalid property length");
			}
			baseProperty.DeserializeProperties(PrototypeGame.P1, input, endianess);
			return baseProperty;
		}

		private static List<BaseProperty> P1_DeserializeBaseProperties(Stream input, Endian endianess, PropertyHash target, bool isTrack)
		{
			List<BaseProperty> list = new List<BaseProperty>();
			while (true)
			{
				ulong num = input.ReadValueU64(endianess);
				if (target != (PropertyHash)0uL && num != (ulong)target)
				{
					break;
				}
				list.Add(P1_DeserializeBaseProperty(input, endianess, target, isTrack));
			}
			input.Position -= 8L;
			return list;
		}

		private static void P2_SerializeBaseProperty(Stream output, Endian endianess, BaseProperty property)
		{
			output.WriteValueU64(property.TypeHash, endianess);
			Stream stream = new MemoryStream();
			property.Serialize(stream, endianess);
			output.WriteValueU32((uint)stream.Length, endianess);
			stream.Seek(0L, SeekOrigin.Begin);
			output.WriteFromStream(stream, stream.Length);
			property.SerializeProperties(PrototypeGame.P2, output, endianess);
			output.WriteValueU64(0uL);
		}

		private static void P2_SerializeBaseProperties(Stream output, Endian endianess, List<BaseProperty> properties)
		{
			foreach (BaseProperty property in properties)
			{
				P2_SerializeBaseProperty(output, endianess, property);
			}
		}

		private static BaseProperty P2_DeserializeBaseProperty(Stream input, Endian endianess, PropertyHash hash, bool isTrack)
		{
			if (hash != (PropertyHash)input.ReadValueU64(endianess))
			{
				throw new Exception("Read wrong property hash");
			}
			BaseProperty baseProperty = ((!isTrack) ? ((BaseProperty)new PropertyConditionGroup(hash)) : ((BaseProperty)new PropertyTrackGroup(hash)));
			if (baseProperty == null)
			{
				throw new NotImplementedException("Unknown property");
			}
			uint num = input.ReadValueU32(endianess);
			long position = input.Position;
			input.ReadValueS32();
			baseProperty.Deserialize(input, endianess);
			baseProperty.DeserializeProperties(PrototypeGame.P2, input, endianess);
			if (input.Position != position + num)
			{
				throw new FormatException("Invalid property length");
			}
			input.ReadValueU64();
			return baseProperty;
		}

		private static List<BaseProperty> P2_DeserializeBaseProperties(Stream input, Endian endianess, PropertyHash target, bool isTrack)
		{
			List<BaseProperty> list = new List<BaseProperty>();
			while (true)
			{
				ulong num = input.ReadValueU64(endianess);
				if (target != (PropertyHash)0uL && num != (ulong)target)
				{
					break;
				}
				list.Add(P2_DeserializeBaseProperty(input, endianess, target, isTrack));
			}
			input.Position -= 8L;
			return list;
		}
	}
}
