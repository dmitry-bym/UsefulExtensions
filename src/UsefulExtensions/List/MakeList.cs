using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UsefulExtensions;

public static partial class UsefulExtensions
{
    public static List<T> MakeList<T>(this T item)
    {
        return new List<T> { item };
    }
    
    public static Span<T> AsSpan<T>(this List<T> list)
    {
        return CollectionsMarshal.AsSpan(list);
    }
    
    public static ReadOnlySpan<T> AsReadOnlySpan<T>(this List<T> list)
    {
        return list.AsSpan();
    }
}