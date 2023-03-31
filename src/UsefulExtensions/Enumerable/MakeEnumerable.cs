namespace UsefulExtensions;

public static partial class UsefulExtensions
{
    public static IEnumerable<T> MakeEnumerable<T>(this T item)
    {
        yield return item;
    }

    public static IEnumerable<T> SelectMany<T>(this IEnumerable<IEnumerable<T>> source)
    {
        return source.SelectMany(x => x);
    }

    public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T?> source)
    {
        return source.Where(x => !x.IsNull()).Cast<T>();
    }
}