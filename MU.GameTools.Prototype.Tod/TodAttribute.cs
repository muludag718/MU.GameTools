using MU.GameTools.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MU.GameTools.Prototype.Tod
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TodAttribute : Attribute
    {
        public string Name;

        public PrototypeGame Game;

        public TodAttribute(string name)
        {
            Name = name;
            Game = PrototypeGame.Any;
        }

        public TodAttribute(string name, PrototypeGame game)
        {
            Name = name;
            Game = game;
        }
    }

}
