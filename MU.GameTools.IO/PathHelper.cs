namespace MU.GameTools.IO;

public static class PathHelper
{
    public static string GetRelativePath(string fromPath, string toPath)
    {
        if (fromPath == null)
        {
            throw new ArgumentNullException("fromPath");
        }
        if (toPath == null)
        {
            throw new ArgumentNullException("toPath");
        }
        if (Path.IsPathRooted(fromPath) && Path.IsPathRooted(toPath) && string.Compare(Path.GetPathRoot(fromPath), Path.GetPathRoot(toPath), StringComparison.OrdinalIgnoreCase) != 0)
        {
            return null;
        }
        List<string> list = new List<string>();
        string[] array = fromPath.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
        string[] array2 = toPath.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
        int num = Math.Min(array.Length, array2.Length);
        int num2 = -1;
        for (int i = 0; i < num && string.Compare(array[i], array2[i], StringComparison.OrdinalIgnoreCase) == 0; i++)
        {
            num2 = i;
        }
        if (num2 == -1)
        {
            return toPath;
        }
        for (int j = num2 + 1; j < array.Length; j++)
        {
            if (array[j].Length > 0)
            {
                list.Add("..");
            }
        }
        for (int k = num2 + 1; k < array2.Length; k++)
        {
            list.Add(array2[k]);
        }
        return Path.Combine(list.ToArray());
    }
}
