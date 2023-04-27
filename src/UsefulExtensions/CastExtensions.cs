namespace UsefulExtensions;

public static class CastExtensions
{
    public static T CastTo<T>(this object? obj) => (T)obj!;
    
    public static T? As<T>(this object? obj) where T: class => obj as T;
}