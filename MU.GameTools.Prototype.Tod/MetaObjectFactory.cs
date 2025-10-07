using MU.GameTools.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MU.GameTools.Prototype.Tod;


public static class MetaObjectFactory
{
    private static Dictionary<string, Type> _p1Lookup;

    private static Dictionary<string, Type> _p2Lookup;

    public static Dictionary<string, Type> _attributeLookup;

    public static Dictionary<string, Type> AttributeLookup
    {
        get
        {
            if (!IsLookupBuild)
            {
                BuildLookup();
            }
            return _attributeLookup;
        }
    }

    private static bool IsLookupBuild
    {
        get
        {
            if (_p1Lookup != null && _p2Lookup != null)
            {
                return _attributeLookup != null;
            }
            return false;
        }
    }

    private static void BuildLookup()
    {
        _p1Lookup = new Dictionary<string, Type>();
        _p2Lookup = new Dictionary<string, Type>();
        Type[] types = Assembly.GetAssembly(typeof(MetaObjectFactory)).GetTypes();
        foreach (Type type in types)
        {
            if (!type.IsSubclassOf(typeof(MetaObject)))
            {
                continue;
            }
            TodAttribute todAttribute = (TodAttribute)type.GetCustomAttribute(typeof(TodAttribute), inherit: false);
            if (todAttribute != null)
            {
                switch (todAttribute.Game)
                {
                    case PrototypeGame.P1:
                        _p1Lookup.Add(todAttribute.Name, type);
                        break;
                    case PrototypeGame.P2:
                        _p2Lookup.Add(todAttribute.Name, type);
                        break;
                    case PrototypeGame.Any:
                        _p1Lookup.Add(todAttribute.Name, type);
                        _p2Lookup.Add(todAttribute.Name, type);
                        break;
                }
            }
        }
        _attributeLookup = new Dictionary<string, Type>
        {
            {
                "BoolAttribute",
                typeof(BoolAttribute)
            },
            {
                "FactionAttribute",
                typeof(FactionAttribute)
            },
            {
                "FloatAttribute",
                typeof(FloatAttribute)
            },
            {
                "IntAttribute",
                typeof(IntAttribute)
            },
            {
                "MatrixAttribute",
                typeof(MatrixAttribute)
            },
            {
                "NameAttribute",
                typeof(NameAttribute)
            },
            {
                "engine::PoseAttribute",
                typeof(PoseAttribute)
            },
            {
                "VectorAttribute",
                typeof(VectorAttribute)
            }
        };
    }

    public static MetaObject CreateTod(string name, PrototypeGame game)
    {
        if (!IsLookupBuild)
        {
            BuildLookup();
        }
        Type value;
        switch (game)
        {
            case PrototypeGame.P1:
                _p1Lookup.TryGetValue(name, out value);
                break;
            case PrototypeGame.P2:
                _p2Lookup.TryGetValue(name, out value);
                break;
            default:
                if (!_p1Lookup.TryGetValue(name, out value))
                {
                    _p2Lookup.TryGetValue(name, out value);
                }
                break;
        }
        if (value == null)
        {
            return null;
        }
        try
        {
            return (MetaObject)Activator.CreateInstance(value);
        }
        catch (TargetInvocationException ex)
        {
            throw ex.InnerException;
        }
    }

    public static MetaAttribute CreateAttribute(string name)
    {
        if (!IsLookupBuild)
        {
            BuildLookup();
        }
        try
        {
            return (MetaAttribute)Activator.CreateInstance(_attributeLookup[name]);
        }
        catch (TargetInvocationException ex)
        {
            throw ex.InnerException;
        }
    }
}
