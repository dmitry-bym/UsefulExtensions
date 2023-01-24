using System.Diagnostics.CodeAnalysis;

namespace UsefulExtensions;

public static class StringExtensions
{
    /// <summary>
    /// Indicates whether the specified string is null or an empty string ("").
    /// </summary>
    /// <param name="value">The string to test.</param>
    /// <returns>true if the value parameter is null or an empty string (""); otherwise, false.</returns>
    public static bool IsNullOrEmpty([NotNullWhen(false)] this string? value)
    {
        return string.IsNullOrEmpty(value);
    }
    
    public static bool IsNotNullOrEmpty([NotNullWhen(true)] this string? value)
    {
        return !value.IsNullOrEmpty();
    }
    
    /// <summary>
    /// Indicates whether a specified string is null, empty, or consists only of white-space characters.
    /// </summary>
    /// <param name="value">The string to test.</param>
    /// <returns>true if the value parameter is null or Empty, or if value consists exclusively of white-space characters.</returns>
    public static bool IsNullOrWhiteSpace([NotNullWhen(false)] this string? value)
    {
        return string.IsNullOrWhiteSpace(value);
    }
    
    public static bool IsNotNullOrWhiteSpace([NotNullWhen(true)] this string? value)
    {
        return !value.IsNullOrWhiteSpace();
    }
}