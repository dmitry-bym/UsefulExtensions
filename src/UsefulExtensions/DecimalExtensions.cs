using System.Numerics;

namespace UsefulExtensions;

public static class DecimalExtensions
{
    public static IEnumerable<T> DivideAndDistributeRemainder<T>(this T dividend, T divider) where T : INumber<T>
    {
        if (divider == default)
        {
            yield break;
        }

        var rest = dividend % divider;
        var result = dividend / divider;

        for (var i = T.Zero; i < divider; i++)
        {
            if (rest > T.Zero)
            {
                rest--;
                yield return result + T.One;
            } else
            {
                yield return result;
            }
        }
    }
}