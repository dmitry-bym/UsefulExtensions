namespace UsefulExtensions;

public static class RangeExtensions
{
    public static IEnumerable<int> Iterate(this Range range)
    {
        var start = range.Start.IsFromEnd switch
        {
            true => 0,
            false => range.Start.Value
        };
        
        var end = range.End.IsFromEnd switch
        {
            true => 0,
            false => range.End.Value
        };

        return RangeHelper.Range(start, end);
    }
}