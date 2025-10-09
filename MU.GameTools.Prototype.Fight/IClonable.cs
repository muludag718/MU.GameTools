using MU.GameTools.Common;

namespace MU.GameTools.Prototype.Fight
{
	internal interface IClonable
	{
		object Clone(PrototypeGame game);
	}
}
