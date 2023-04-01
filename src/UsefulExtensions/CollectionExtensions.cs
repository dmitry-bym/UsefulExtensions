namespace UsefulExtensions;

public static class CollectionExtensions
{
    public static bool IsEmpty<T>(this ICollection<T> collection)
    {
        return collection.Count == 0;
    }

    public static void AddRangeIf<T>(this ICollection<T> collection, IEnumerable<T> elements, Func<T, bool> predicate)
    {
        foreach (var element in elements)
        {
            if(predicate(element))
                collection.Add(element);
        }
    }
}