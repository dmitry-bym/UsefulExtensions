using System.Diagnostics.CodeAnalysis;

namespace UsefulExtensions;

public static class GuidExtensions
{
    /// <summary>
    /// Indicates whether the specified guid is null or an empty guid (Guid.Empty).
    /// </summary>
    /// <param name="value">guid to test.</param>
    /// <returns>true if the value parameter is null or an empty guid (Guid.Empty); otherwise, false.</returns>
    public static bool IsNullOrEmpty([NotNullWhen(false)] this Guid? value)
    {
        return value.IsNull() || value.Value.IsEmpty();
    }
    
    public static bool IsEmpty(this Guid value)
    {
        return value == Guid.Empty;
    }
}