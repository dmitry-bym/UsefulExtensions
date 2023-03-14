using System.Numerics;

namespace UsefulExtensions;

public static class TupleExtensions
{
}

public static class DecimalExtensions
{
    public static IEnumerable<int> DivideAndDistributeRemainder(this int dividend, int divider)
    {
        if (divider == default)
        {
            yield break;
        }

        var rest = dividend % divider;
        var result = dividend / divider;

        for (int i = 0; i < divider; i++)
        {
            if (rest > 0)
            {
                rest--;
                yield return result + 1;
            } else
            {
                yield return result;
            }
        }
    }
}

public static class RandomExtensions
{
    public static Task Random(this ICollection<Task> z)
    {
        return Task.CompletedTask;
    }
}

public static class TaskExtensions
{
    public static Task WhenAll(this IEnumerable<Task> tasks)
    {
        return Task.WhenAll(tasks);
    }
    
    public static Task<Task> WhenAny(this IEnumerable<Task> tasks)
    {
        return Task.WhenAny(tasks);
    }
}