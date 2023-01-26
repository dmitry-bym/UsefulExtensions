namespace UsefulExtensions;

public static class AverageExtensions
{
    public static (decimal, decimal) Average<T>(this IEnumerable<T> collection, 
        Func<T, decimal> selector1, 
        Func<T, decimal> selector2)
    {
        var result = AverageInner(collection, selector1, selector2);
        return (result[0], result[1]);
    }
    
    public static (decimal, decimal, decimal) Average<T>(this IEnumerable<T> collection, 
        Func<T, decimal> selector1, 
        Func<T, decimal> selector2,
        Func<T, decimal> selector3)
    {
        var result = AverageInner(collection, selector1, selector2, selector3);
        return (result[0], result[1], result[2]);
    }

    public static (decimal, decimal, decimal, decimal) Average<T>(this IEnumerable<T> collection, 
        Func<T, decimal> selector1, 
        Func<T, decimal> selector2,
        Func<T, decimal> selector3,
        Func<T, decimal> selector4)
    {
        var result = AverageInner(collection, selector1, selector2, selector3, selector4);
        return (result[0], result[1], result[2], result[3]);
    }

    public static (decimal, decimal, decimal, decimal, decimal) Average<T>(this IEnumerable<T> collection, 
        Func<T, decimal> selector1, 
        Func<T, decimal> selector2,
        Func<T, decimal> selector3,
        Func<T, decimal> selector4,
        Func<T, decimal> selector5)
    {
        var result = AverageInner(collection, selector1, selector2, selector3, selector4, selector5);
        return (result[0], result[1], result[2], result[3], result[4]);
    }

    private static decimal[] AverageInner<T>(IEnumerable<T> collection, params Func<T, decimal>[] selectors)
    {
        var sums = new decimal[selectors.Length];
        var count = 0;
        foreach (var elem in collection)
        {
            for (int i = 0; i < selectors.Length; i++)
            {
                sums[i] += selectors[i](elem);
            }

            count++;
        }
        
        for (int i = 0; i < selectors.Length; i++)
        {
            sums[i] /= count;
        }

        return sums;
    }
}