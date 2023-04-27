namespace UsefulExtensions;

public static partial class TupleAwaitableExtensions
{
    public static Task<Task> WhenAny<T1, T2>(this (Task<T1>, Task<T2>) tuple)
    {
        var (i1, i2) = tuple;
        return Task.WhenAny(i1, i2);
    }

    public static Task<Task> WhenAny<T1, T2, T3>(this (Task<T1>, Task<T2>, Task<T3>) tuple)
    {
        var (i1, i2, i3) = tuple;
        return Task.WhenAny(i1, i2, i3);
    }

    public static Task<Task> WhenAny<T1, T2, T3, T4>(
        this (Task<T1>, Task<T2>, Task<T3>, Task<T4>) tuple)
    {
        var (i1, i2, i3, i4) = tuple;
        return Task.WhenAny(i1, i2, i3, i4);
    }

    public static Task<Task> WhenAny<T1, T2, T3, T4, T5>(
        this (Task<T1>, Task<T2>, Task<T3>, Task<T4>, Task<T5>) tuple)
    {
        var (i1, i2, i3, i4, i5) = tuple;
        return Task.WhenAny(i1, i2, i3, i4, i5);
    }

    public static Task<Task> WhenAny<T1, T2, T3, T4, T5, T6>(
        this (Task<T1>, Task<T2>, Task<T3>, Task<T4>, Task<T5>, Task<T6>) tuple)
    {
        var (i1, i2, i3, i4, i5, i6) = tuple;
        return Task.WhenAny(i1, i2, i3, i4, i5, i6);
    }

    public static Task<Task> WhenAny<T1, T2, T3, T4, T5, T6, T7>(
        this (Task<T1>, Task<T2>, Task<T3>, Task<T4>, Task<T5>, Task<T6>, Task<T7>) tuple)
    {
        var (i1, i2, i3, i4, i5, i6, i7) = tuple;
        return Task.WhenAny(i1, i2, i3, i4, i5, i6, i7);
    }
    
    public static Task<Task> WhenAny<T1, T2, T3, T4, T5, T6, T7, T8>(
        this (Task<T1>, Task<T2>, Task<T3>, Task<T4>, Task<T5>, Task<T6>, Task<T7>, Task<T8>) tuple)
    {
        var (i1, i2, i3, i4, i5, i6, i7, i8) = tuple;
        return Task.WhenAny(i1, i2, i3, i4, i5, i6, i7, i8);
    }
}