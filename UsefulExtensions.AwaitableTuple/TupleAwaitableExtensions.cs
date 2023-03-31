using System.Collections;
using System.Collections.ObjectModel;

namespace UsefulExtensions.AwaitableTuple;

public static class TupleAwaitableExtensions
{
    public static async Task<(T1, T2)> WhenAll<T1, T2>(this (Task<T1>, Task<T2>) tuple)
    {
        await Task.WhenAll(tuple.Item1, tuple.Item2);
        return (tuple.Item1.Result, tuple.Item2.Result);
    }

    public static async Task<(T1, T2, T3)> WhenAll<T1, T2, T3>(this (Task<T1>, Task<T2>, Task<T3>) tuple)
    {
        var (i1, i2, i3) = tuple;
        await Task.WhenAll(i1, i2, i3);
        return (i1.Result, i2.Result, i3.Result);
    }

    public static async Task<(T1, T2, T3, T4)> WhenAll<T1, T2, T3, T4>(
        this (Task<T1>, Task<T2>, Task<T3>, Task<T4>) tuple)
    {
        var (i1, i2, i3, i4) = tuple;
        await Task.WhenAll(i1, i2, i3, i4);
        return (i1.Result, i2.Result, i3.Result, i4.Result);
    }

    public static async Task<(T1, T2, T3, T4, T5)> WhenAll<T1, T2, T3, T4, T5>(
        this (Task<T1>, Task<T2>, Task<T3>, Task<T4>, Task<T5>) tuple)
    {
        var (i1, i2, i3, i4, i5) = tuple;
        await Task.WhenAll(i1, i2, i3, i4, i5);
        return (i1.Result, i2.Result, i3.Result, i4.Result, i5.Result);
    }

    public static async Task<(T1, T2, T3, T4, T5, T6)> WhenAll<T1, T2, T3, T4, T5, T6>(
        this (Task<T1>, Task<T2>, Task<T3>, Task<T4>, Task<T5>, Task<T6>) tuple)
    {
        var (i1, i2, i3, i4, i5, i6) = tuple;
        await Task.WhenAll(i1, i2, i3, i4, i5, i6);
        return (i1.Result, i2.Result, i3.Result, i4.Result, i5.Result, i6.Result);
    }

    public static async Task<(T1, T2, T3, T4, T5, T6, T7)> WhenAll<T1, T2, T3, T4, T5, T6, T7>(
        this (Task<T1>, Task<T2>, Task<T3>, Task<T4>, Task<T5>, Task<T6>, Task<T7>) tuple)
    {
        var (i1, i2, i3, i4, i5, i6, i7) = tuple;
        await Task.WhenAll(i1, i2, i3, i4, i5, i6, i7);
        return (i1.Result, i2.Result, i3.Result, i4.Result, i5.Result, i6.Result, i7.Result);
    }
}