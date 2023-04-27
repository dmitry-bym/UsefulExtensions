namespace UsefulExtensions.Core;

public static class TupleAdd
{
    public static (T1, T2, T3) Append<T1, T2, T3>(this (T1, T2) tuple, T3 element)
    {
        return (tuple.Item1, tuple.Item2, element);
    }
    
    public static (T1, T2, T3, T4) Append<T1, T2, T3, T4>(this (T1, T2, T3) tuple, T4 element)
    {
        return (tuple.Item1, tuple.Item2, tuple.Item3, element);
    }
    
    public static (T1, T2, T3, T4, T5) Append<T1, T2, T3, T4, T5>(this (T1, T2, T3, T4) tuple, T5 element)
    {
        return (tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, element);
    }
    
    public static (T1, T2, T3, T4, T5, T6) Append<T1, T2, T3, T4, T5, T6>(this (T1, T2, T3, T4, T5) tuple, T6 element)
    {
        return (tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, element);
    }
    
    public static (T1, T2, T3, T4, T5, T6, T7) Append<T1, T2, T3, T4, T5, T6, T7>(this (T1, T2, T3, T4, T5, T6) tuple, T7 element)
    {
        return (tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6, element);
    }
}