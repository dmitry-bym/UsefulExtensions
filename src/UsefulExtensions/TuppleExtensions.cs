namespace UsefulExtensions;

public static class TupleExtensions
{  
    public static (decimal, decimal) Average(this IEnumerable<(decimal, decimal)> tuple)
    {
        var sumX = 0m;
        var sumY = 0m;
        var count = 0;
        foreach (var (x, y) in tuple)
        {
            sumX += x;
            sumY += y;
            count++;
        }
        return (sumX / count, sumY / count);
    }
    
    public static (double, double) Average(this IEnumerable<(double, double)> tuple)
    {
        var sumX = 0d;
        var sumY = 0d;
        var count = 0;
        foreach (var (x, y) in tuple)
        {
            sumX += x;
            sumY += y;
            count++;
        }
        return (sumX / count, sumY / count);
    }
}

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