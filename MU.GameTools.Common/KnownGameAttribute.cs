namespace MU.GameTools.Common;

[AttributeUsage(AttributeTargets.Class)]
public class KnownGameAttribute : Attribute
{
    public PrototypeGame Game;

    public KnownGameAttribute(PrototypeGame game)
    {
        Game = game;
    }
}
