namespace UsefulExtensions.Core.Array;

public static class ArrayExtensions
{
    public static void Fill<T>(this T[] array, T elem)
    {
        System.Array.Fill(array, elem);
    }
    
    public static void Fill<T>(this T[] array, T elem, int startIndex)
    {
        System.Array.Fill(array, elem, startIndex, array.Length);
    }
    
    public static void Fill<T>(this T[] array, T elem, int startIndex, int count)
    {
        System.Array.Fill(array, elem, startIndex, count);
    }
}