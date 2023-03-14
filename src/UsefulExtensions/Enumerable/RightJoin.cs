namespace UsefulExtensions;

public static partial class UsefulExtensions
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
}