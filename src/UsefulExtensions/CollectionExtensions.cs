namespace UsefulExtensions;

public static class CollectionExtensions
{
    public static bool IsEmpty<T>(this ICollection<T> collection)
    {
        return collection.Count == 0;
    }
    
    public static bool IsNotEmpty<T>(this ICollection<T> collection)
    {
        return !collection.IsEmpty();
    }
    
    public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> elements)
    {
        foreach (var element in elements)
        {
            collection.Add(element);
        }
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