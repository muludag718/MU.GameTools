using System.Text.RegularExpressions;
using System.Text;

namespace MU.GameTools.IO;

public static class StringHelpers
{
    public static uint HashFileName(this string input, uint seed)
    {
        if (input.StartsWith("\\"))
        {
            input = input[1..];
        }
        byte[] bytes = Encoding.ASCII.GetBytes(input);
        foreach (byte b in bytes)
        {
            seed = (seed << 5) - seed;
            seed = ((b >= 97) ? (seed + b) : (seed + (uint)(32 + b)));
        }
        return seed;
    }

    public static uint HashFileName(this string input)
    {
        return HashFileName(input, 0u);
    }

    public static ulong HashX65599(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return 0uL;
        }
        return input.Aggregate(0uL, (ulong current, char t) => (current * 65599) ^ t);
    }

    public static string SeparateCamelCase(this string input)
    {
        return Regex.Replace(input, "([A-Z])", " $1", RegexOptions.Compiled).Trim();
    }
}
