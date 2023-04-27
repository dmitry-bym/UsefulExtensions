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
        var sum1 = TR1.Zero;
        var sum2 = TR2.Zero;
        var count = 0;

        foreach (var elem in collection)
        {
            sum1 += selector1(elem);
            sum2 += selector2(elem);
            count++;   
        }
        
        if (count == 0)
            throw new ArgumentOutOfRangeException(nameof(collection));
        
        return (sum1 / count, sum2 / count);
    }
    
    public static (TR1, TR2, TR3) Average<T, TR1, TR2, TR3>(this IEnumerable<T> collection, 
        Func<T, TR1> selector1, 
        Func<T, TR2> selector2, 
        Func<T, TR3> selector3) 
        where TR1 : INumberBase<TR1>, IDivisionOperators<TR1, int, TR1>
        where TR2 : INumberBase<TR2>, IDivisionOperators<TR2, int, TR2>
        where TR3 : INumberBase<TR3>, IDivisionOperators<TR3, int, TR3>
    {
        var sum1 = TR1.Zero;
        var sum2 = TR2.Zero;
        var sum3 = TR3.Zero;
        var count = 0;

        foreach (var elem in collection)
        {
            sum1 += selector1(elem);
            sum2 += selector2(elem);
            sum3 += selector3(elem);
            count++;   
        }
        
        if (count == 0)
            throw new ArgumentOutOfRangeException(nameof(collection));
        
        return (sum1 / count, sum2 / count, sum3 / count);
    }
}