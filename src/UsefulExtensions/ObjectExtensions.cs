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
}