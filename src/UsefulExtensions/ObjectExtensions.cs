using System.Diagnostics.CodeAnalysis;

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
        return value == null;
    }
    
    public static T Cast<T>(this object? value)
    {
        return (T)value!;
    }
    
    public static T? As<T>(this object? value) where T : class
    {
        return value as T;
    }
}