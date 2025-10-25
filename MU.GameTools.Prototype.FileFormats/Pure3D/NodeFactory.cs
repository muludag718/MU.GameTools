using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
    internal static class NodeFactory
    {
        private static Dictionary<uint, Type> _p1Lookup;

        private static Dictionary<uint, Type> _p2Lookup;

        private static bool IsLookupBuild
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
            _p1Lookup = new Dictionary<uint, Type>();
            _p2Lookup = new Dictionary<uint, Type>();
            Type[] types = Assembly.GetAssembly(typeof(NodeFactory)).GetTypes();
            foreach (Type type in types)
            {
                if (!type.IsSubclassOf(typeof(BaseNode)))
                {
                    continue;
                }
                KnownGameAttribute knownGameAttribute = (KnownGameAttribute)type.GetCustomAttribute(typeof(KnownGameAttribute), inherit: false);
                if (knownGameAttribute == null)
                {
                    continue;
                }
                object[] customAttributes = type.GetCustomAttributes(typeof(KnownTypeAttribute), inherit: false);
                if (customAttributes.Length == 0)
                {
                    continue;
                }
                for (int j = 0; j < customAttributes.Length; j++)
                {
                    KnownTypeAttribute knownTypeAttribute = (KnownTypeAttribute)customAttributes[j];
                    switch (knownGameAttribute.Game)
                    {
                        case PrototypeGame.P1:
                            _p1Lookup.Add(knownTypeAttribute.Id, type);
                            break;
                        case PrototypeGame.P2:
                            _p2Lookup.Add(knownTypeAttribute.Id, type);
                            break;
                        case PrototypeGame.Any:
                            _p1Lookup.Add(knownTypeAttribute.Id, type);
                            _p2Lookup.Add(knownTypeAttribute.Id, type);
                            break;
                    }
                }
            }
        }

        public static BaseNode CreateNode(uint typeId, PrototypeGame game = PrototypeGame.Any)
        {
            if (!IsLookupBuild)
            {
                BuildLookup();
            }
            Type value;
            switch (game)
            {
                case PrototypeGame.P1:
                    _p1Lookup.TryGetValue(typeId, out value);
                    break;
                case PrototypeGame.P2:
                    _p2Lookup.TryGetValue(typeId, out value);
                    break;
                default:
                    _p1Lookup.TryGetValue(typeId, out value);
                    break;
            }
            if (value == null)
            {
                return null;
            }
            try
            {
                return (BaseNode)Activator.CreateInstance(value);
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
