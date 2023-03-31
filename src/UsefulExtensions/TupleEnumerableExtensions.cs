using System.Numerics;

namespace UsefulExtensions;

public static class TupleEnumerableExtensions
{
    /// <summary>
    /// Start inclusive. End exclusive
    /// </summary>
    /// <param name="tuple"></param>
    /// <returns></returns>
    public static IEnumerable<int> Range(this (int Start, int End) tuple)
    {
        return RangeHelper.Range(tuple.Start, tuple.End);
    }

    /// <summary>
    /// Start inclusive. End exclusive
    /// </summary>
    /// <param name="tuple"></param>
    /// <returns></returns>
    public static IEnumerable<T> Range<T>(this (T Start, T End, T Step) tuple)
        where T : INumber<T>
    {
        return RangeHelper.Range(tuple.Start, tuple.End, tuple.Step);
    }
}