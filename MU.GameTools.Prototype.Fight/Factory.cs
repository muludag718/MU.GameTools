using System;
using System.Collections.Generic;
using System.Reflection;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.Fight
{
	public abstract class Factory<TType, TAttribute> where TType : FightNode where TAttribute : KnownHashAttribute
	{
		private static Dictionary<ulong, Type> _p1Lookup;

		private static Dictionary<ulong, Type> _p2Lookup;

		private static bool IsLookupBuilt
		{
			get
			{
				if (_p1Lookup != null)
				{
					return _p2Lookup != null;
				}
				return false;
			}
		}

		private static void BuildLookup()
		{
			_p1Lookup = new Dictionary<ulong, Type>();
			_p2Lookup = new Dictionary<ulong, Type>();
			Type[] types = Assembly.GetAssembly(typeof(TType)).GetTypes();
			foreach (Type type in types)
			{
				if (!type.IsSubclassOf(typeof(TType)))
				{
					continue;
				}
				object[] customAttributes = type.GetCustomAttributes(typeof(TAttribute), inherit: false);
				if (customAttributes.Length == 0)
				{
					continue;
				}
				for (int j = 0; j < customAttributes.Length; j++)
				{
					TAttribute val = (TAttribute)customAttributes[j];
					if (type.Namespace.Contains(".Prototype1."))
					{
						_p1Lookup.Add(val.Hash, type);
						continue;
					}
					if (type.Namespace.Contains(".Prototype2."))
					{
						_p2Lookup.Add(val.Hash, type);
						continue;
					}
					_p1Lookup.Add(val.Hash, type);
					_p2Lookup.Add(val.Hash, type);
				}
			}
		}

		public static List<Type> GetTypes(PrototypeGame game)
		{
			if (!IsLookupBuilt)
			{
				BuildLookup();
			}
			return new List<Type>(((game == PrototypeGame.P1) ? _p1Lookup : _p2Lookup).Values);
		}

		public static Type GetType(PrototypeGame game, ulong typeId)
		{
			if (!IsLookupBuilt)
			{
				BuildLookup();
			}
			Dictionary<ulong, Type> dictionary = ((game == PrototypeGame.P1) ? _p1Lookup : _p2Lookup);
			if (!dictionary.ContainsKey(typeId))
			{
				return null;
			}
			return dictionary[typeId];
		}

		public static TType Build(PrototypeGame game, ulong typeId)
		{
			if (!IsLookupBuilt)
			{
				BuildLookup();
			}
			Dictionary<ulong, Type> dictionary = ((game == PrototypeGame.P1) ? _p1Lookup : _p2Lookup);
			if (!dictionary.ContainsKey(typeId))
			{
				return null;
			}
			try
			{
				TType val = (TType)Activator.CreateInstance(dictionary[typeId]);
				val.TypeHash = typeId;
				return val;
			}
			catch (TargetInvocationException ex)
			{
				throw ex.InnerException;
			}
		}
	}
}
