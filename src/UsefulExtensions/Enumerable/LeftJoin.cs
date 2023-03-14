namespace UsefulExtensions;

public static partial class UsefulExtensions
{
    
    public static IEnumerable<T> MergeLeft<T, TKey>(this IEnumerable<T> left, IEnumerable<T> right, Func<T, TKey> selector) where TKey : notnull
    {
        return left.Merge(right, selector, (leftItem, _) => leftItem);
    }

    public static IEnumerable<T> MergeRight<T, TKey>(this IEnumerable<T> left, IEnumerable<T> right, Func<T, TKey> selector) where TKey : notnull
    {
        return left.Merge(right, selector, (_, rightItem) => rightItem);
    }

    public delegate T MergeResolverDelegate<T>(T leftItem, T rightItem);

    public static IEnumerable<T> Merge<T, TKey>(this IEnumerable<T> left, IEnumerable<T> right, Func<T, TKey> selector, MergeResolverDelegate<T> resolver) where TKey : notnull
    {
        return left.Merge(right, selector, Resolve);

        T Resolve(IEnumerable<T> leftGroup, IEnumerable<T> rightGroup)
        {
            using var leftEnumerator = leftGroup.GetEnumerator();
            using var rightEnumerator = rightGroup.GetEnumerator();
                
            return (leftEnumerator.MoveNext(), rightEnumerator.MoveNext()) switch
            {
                (true, true) => resolver(leftEnumerator.Current, rightEnumerator.Current),
                (true, false) => leftEnumerator.Current,
                (false, true) => rightEnumerator.Current,
                _ => throw new InvalidOperationException("Both enumerators are empty")
            };
        }
    }

    public delegate T MergeGroupResolverDelegate<T>(IEnumerable<T> leftGroup, IEnumerable<T> rightGroup);

    public static IEnumerable<T> Merge<T, TKey>(this IEnumerable<T> left, IEnumerable<T> right, Func<T, TKey> selector, MergeGroupResolverDelegate<T> resolver) where TKey : notnull
    {
        var leftLookup = left.ToLookup(selector);
        var rightLookup = right.ToLookup(selector);

        var keys = leftLookup.Select(x => x.Key).Concat(rightLookup.Select(x => x.Key)).Distinct();

        foreach (var key in keys)
        {
            var leftGroup = leftLookup[key];
            var rightGroup = rightLookup[key];

            yield return resolver(leftGroup, rightGroup);
        }
    }
}