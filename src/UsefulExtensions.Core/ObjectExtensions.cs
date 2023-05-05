using System.Diagnostics.CodeAnalysis;
using UsefulExtensions.Core;

namespace UsefulExtensions;

public static class ObjectExtensions
{
    /// <summary>
    /// Indicates whether the specified object is null.
    /// </summary>
    /// <param name="value">object to test.</param>
    /// <returns>true if the value parameter is null; otherwise, false.</returns>
    public static bool IsNull([NotNullWhen(false)] this object? value)
    {
        return value is null;
    }
    
    /// <summary>
    /// Indicates whether the specified object is null.
    /// </summary>
    /// <param name="value">object to test.</param>
    /// <returns>true if the value parameter is null; otherwise, false.</returns>
    public static bool IsNull<T>([NotNullWhen(false)] this T? value) where T : struct
    {
        return !value.HasValue;
    }
    
    public static bool IsEmpty<T>(this T value) where T : IHasEmpty<T>
    {
        return T.Empty.Equals(value);
    }
}