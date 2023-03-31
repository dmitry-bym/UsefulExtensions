using System.Numerics;

namespace UsefulExtensions;

public static class AverageExtensions
{
    public static (TR1, TR2) Average<T, TR1, TR2>(this IEnumerable<T> collection, 
        Func<T, TR1> selector1, 
        Func<T, TR2> selector2) 
        where TR1 : INumberBase<TR1>, IDivisionOperators<TR1, int, TR1>
        where TR2 : INumberBase<TR2>, IDivisionOperators<TR2, int, TR2>
    {
        using var enumerator =  collection.GetEnumerator();
        if (!enumerator.MoveNext())
            throw new ArgumentOutOfRangeException(nameof(collection));
        
        var sum1 = selector1(enumerator.Current);
        var sum2 = selector2(enumerator.Current);
        var count = 1;
        
        while (enumerator.MoveNext())
        {
            sum1 += selector1(enumerator.Current);
            sum2 += selector2(enumerator.Current);
            count++;
        }
        
        return (sum1 / count, sum2 / count);
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

    public static (decimal, decimal, decimal, decimal, decimal, decimal) Average<T, TR1>(this IEnumerable<T> collection, 
        Func<T, decimal> selector1, 
        Func<T, decimal> selector2,
        Func<T, decimal> selector3,
        Func<T, decimal> selector4,
        Func<T, decimal> selector5,
        Func<T, decimal> selector6)
    {
        var result = AverageInner(collection, selector1, selector2, selector3, selector4, selector5, selector6);
        return (result[0], result[1], result[2], result[3], result[4], result[5]);
    }

    private static decimal[] AverageInner<T>(IEnumerable<T> collection, params Func<T, decimal>[] selectors)
    {
        var sums = new decimal[selectors.Length];
        var count = 0;
        //todo try get span
        using (var enumerator =  collection.GetEnumerator())
        {
            while (enumerator.MoveNext())
            {
                for (int i = 0; i < selectors.Length; i++)
                {
                    sums[i] += selectors[i](enumerator.Current);
                }

                count++;
            }
        }
        
        for (int i = 0; i < selectors.Length; i++)
        {
            sums[i] /= count;
        }

        return sums;
    }
}