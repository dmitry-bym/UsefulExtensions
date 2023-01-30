namespace UsefulExtensions;

public static class EnumerableExtensions
{
    public static IEnumerable<TResult> RightJoin<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer,
        IEnumerable<TInner> inner,
        Func<TOuter, TKey> outerKeySelector,
        Func<TInner, TKey> innerKeySelector,
        Func<TOuter?, TInner, TResult> resultSelector,
        IEqualityComparer<TKey>? comparer = null)
    {
        return LeftJoin(inner, outer, innerKeySelector, outerKeySelector, (a, b) => resultSelector(b, a), comparer);
    }

    public static IEnumerable<TResult> LeftJoin<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer,
        IEnumerable<TInner> inner,
        Func<TOuter, TKey> outerKeySelector,
        Func<TInner, TKey> innerKeySelector,
        Func<TOuter, TInner?, TResult> resultSelector,
        IEqualityComparer<TKey>? comparer = null)
    {
        var innerLookup = inner.ToLookup(innerKeySelector, x => x, comparer);
        foreach (var outerElem in outer)
        {
            var joined = innerLookup[outerKeySelector(outerElem)];
            var count = 0;
            foreach (var item in joined)
            {
                yield return resultSelector(outerElem, item);
                count++;
            }

            if (count == 0)
            {
                yield return resultSelector(outerElem, default);
            }
        }
    }
}