using System.Runtime.CompilerServices;

namespace UsefulExtensions;

public static class AsyncEnumerableExtensions
{
    public static async IAsyncEnumerable<T> Where<T>(this IAsyncEnumerable<T> source, Func<T, bool> predicate)
    {
        await foreach (var elem in source)
        {
            if (predicate(elem))
                yield return elem;
        }
    }
    
    public static async IAsyncEnumerable<TResult> Select<T, TResult>(this IAsyncEnumerable<T> source, Func<T, TResult> selector)
    {
        await foreach (var elem in source)
        { 
            yield return selector(elem);
        }
    }
    
    public static async IAsyncEnumerable<TResult> SelectMany<T, TResult>(this IAsyncEnumerable<T> source, Func<T, IEnumerable<TResult>> selector)
    {
        await foreach (var elem in source)
        {
            foreach (var result in selector(elem))
            {
                yield return result;
            }
        }
    }
    
    public static async IAsyncEnumerable<(T1, T2)> Zip<T1, T2>(this IAsyncEnumerable<T1> source,  IAsyncEnumerable<T2> source2)
    {
        var enumerator1 = source.GetAsyncEnumerator();
        var enumerator2 = source2.GetAsyncEnumerator();

        while (await enumerator1.MoveNextAsync() && await enumerator2.MoveNextAsync())
        {
            yield return (enumerator1.Current, enumerator2.Current);
        }
    }
    
    public static async IAsyncEnumerable<T> Take<T>(this IAsyncEnumerable<T> source, int count)
    {
        var enumerator = source.GetAsyncEnumerator();
        while (await enumerator.MoveNextAsync() && count > 0)
        {
            yield return enumerator.Current;
            count--;
        }
    }
    
    public static async IAsyncEnumerable<T> Skip<T>(this IAsyncEnumerable<T> source, int count)
    {
        var enumerator = source.GetAsyncEnumerator();
        while (await enumerator.MoveNextAsync() && count > 0)
        {
            count--;
        }
        
        while (await enumerator.MoveNextAsync())
        {
            yield return enumerator.Current;
        }
    }
    
    public static async IAsyncEnumerable<T> Distinct<T>(this IAsyncEnumerable<T> source, IEqualityComparer<T>? comparer = null)
    {
        var set = new HashSet<T>(comparer);
        await foreach (var elem in source)
        {
            if (set.Add(elem))
                yield return elem;
        }
    }
    
    public static async IAsyncEnumerable<T> Concat<T>(this IAsyncEnumerable<T> source, IAsyncEnumerable<T> source2)
    {
        await foreach (var elem in source)
        {
            yield return elem;
        }
        
        await foreach (var elem in source2)
        {
            yield return elem;
        }
    }
    
    public static async IAsyncEnumerable<IAsyncEnumerable<T>> Batch<T>(this IAsyncEnumerable<T> source, int batchSize)
    {
        var enumerator = source.GetAsyncEnumerator();
        while (await enumerator.MoveNextAsync())
        {
            var buffer = new T[batchSize];
            buffer[0] = enumerator.Current;
            
            var index = 1;
            while (index < batchSize && await enumerator.MoveNextAsync())
            {
                buffer[index] = enumerator.Current;
            }
            
            if(index == batchSize)
                yield return buffer;
            else
                yield return buffer.Take(index).ToAsyncEnumerable();
        }
    }
}