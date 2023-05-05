namespace UsefulExtensions.Core;

public interface IHasEmpty<out T>
{
    public static abstract T Empty { get; }
}