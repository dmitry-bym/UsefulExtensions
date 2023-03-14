namespace UsefulExtensions;

public static partial class UsefulExtensions
{
    public static IEnumerable<T> MakeEnumerable<T>(this T item)
    {
        yield return item;
    }
}