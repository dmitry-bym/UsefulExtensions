namespace UsefulExtensions.Core;

public static class TupleEnumeration
{
    public static IEnumerable<T> ToEnumerable<T>(this (T, T) tuple)
    {
        yield return tuple.Item1;
        yield return tuple.Item2;
    }
    
    public static IEnumerable<T> ToEnumerable<T>(this (T, T, T) tuple)
    {
        yield return tuple.Item1;
        yield return tuple.Item2;
        yield return tuple.Item3;
    }
    
    public static IEnumerable<T> ToEnumerable<T>(this (T, T, T, T) tuple)
    {
        yield return tuple.Item1;
        yield return tuple.Item2;
        yield return tuple.Item3;
        yield return tuple.Item4;
    }
    
    public static IEnumerable<T> ToEnumerable<T>(this (T, T, T, T, T) tuple)
    {
        yield return tuple.Item1;
        yield return tuple.Item2;
        yield return tuple.Item3;
        yield return tuple.Item4;
        yield return tuple.Item5;
    }
    
    public static IEnumerable<T> ToEnumerable<T>(this (T, T, T, T, T, T) tuple)
    {
        yield return tuple.Item1;
        yield return tuple.Item2;
        yield return tuple.Item3;
        yield return tuple.Item4;
        yield return tuple.Item5;
        yield return tuple.Item6;
    }
    
    public static IEnumerable<T> ToEnumerable<T>(this (T, T, T, T, T, T, T) tuple)
    {
        yield return tuple.Item1;
        yield return tuple.Item2;
        yield return tuple.Item3;
        yield return tuple.Item4;
        yield return tuple.Item5;
        yield return tuple.Item6;
        yield return tuple.Item7;
    }
    
    public static IEnumerable<T> ToEnumerable<T>(this (T, T, T, T, T, T, T, T) tuple)
    {
        yield return tuple.Item1;
        yield return tuple.Item2;
        yield return tuple.Item3;
        yield return tuple.Item4;
        yield return tuple.Item5;
        yield return tuple.Item6;
        yield return tuple.Item7;
        yield return tuple.Item8;
    }
}