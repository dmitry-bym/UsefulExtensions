using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace UsefulExtensions.Span;

public static class SpanExtensions
{
    public static Span<T> AsSpan<T>(this List<T> list)
    {
        return CollectionsMarshal.AsSpan(list);
    }
    
    public static ReadOnlySpan<T> AsReadOnlySpan<T>(this List<T> list)
    {
        return list.AsSpan();
    }
    
    public static ReadOnlySpan<T> AsReadOnlySpan<T>(this T[] list)
    {
        return new ReadOnlySpan<T>(list);
    }
    
    public static bool TryGetSpan<T>(this IEnumerable<T> collection, out ReadOnlySpan<T> span)
    {
        if (collection is List<T> list)
        {
            span = list.AsReadOnlySpan();
            return true;
        }
        
        if (collection is T[] array)
        {
            span = array.AsReadOnlySpan();
            return true;
        }

        span = null;
        return false;
    }
}