namespace UsefulExtensions;

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