namespace UsefulExtensions;

public static partial class UsefulExtensions
{
    public static List<T> MakeList<T>(this T item)
    {
        return new List<T> { item };
    }
}