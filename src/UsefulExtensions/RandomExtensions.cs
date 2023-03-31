using System.Collections;

namespace UsefulExtensions;

public static class RandomExtensions
{
    public static ICollection<T> Random<T>(this ICollection<T> z)
    {
        ICollection<>
    }
}

internal class CountableEnumerable<T> : ICollection<T>
{
    private readonly IEnumerable<T> _enumerable;
    
    public CountableEnumerable(IEnumerable<T> enumerable, int count)
    {
        _enumerable = enumerable;
        Count = count;
    }
    public IEnumerator<T> GetEnumerator()
    {
        return _enumerable.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(T item)
    {
        throw new NotSupportedException();
    }

    public void Clear()
    {
        throw new NotSupportedException();
    }

    public bool Contains(T item)
    {
        throw new NotSupportedException();
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public bool Remove(T item)
    {
        throw new NotSupportedException();
    }

    public int Count { get; }
    
    public bool IsReadOnly => true;
}

internal static class RandomHelper
{
    public static Random Random { get; set; } = new();
}