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
}