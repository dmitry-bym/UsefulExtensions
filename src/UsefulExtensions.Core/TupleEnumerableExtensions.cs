using System.Numerics;
using UsefulExtensions.Core;

// ReSharper disable once CheckNamespace
namespace UsefulExtensions;

public static class TupleEnumerableExtensions
{
    /// <summary>
    /// Start inclusive. End exclusive
    /// </summary>
    /// <param name="tuple"></param>
    /// <returns></returns>
    public static IEnumerable<int> Range(this (int Start, int Count) tuple)
    {
        return Enumerable.Range(tuple.Start, tuple.Count);
    }
    
    /// <summary>
    /// Start inclusive. End exclusive
    /// </summary>
    /// <param name="tuple"></param>
    /// <returns></returns>
    public static IEnumerable<T> Range<T>(this (T Start, int Count) tuple)
        where T : INumber<T>
    {
        return RangeHelper.Range(tuple.Start, tuple.Count);
    }

    /// <summary>
    /// Start inclusive. End exclusive
    /// </summary>
    /// <param name="tuple"></param>
    /// <returns></returns>
    public static IEnumerable<T> Range<T>(this (T Start, int Count, T Step) tuple)
        where T : INumber<T>
    {
        return RangeHelper.Range(tuple.Start, tuple.Count, tuple.Step);
    }
}