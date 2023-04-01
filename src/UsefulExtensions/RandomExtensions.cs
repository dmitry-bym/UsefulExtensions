using UsefulExtensions.Span;

namespace UsefulExtensions;

public static class RandomExtensions
{
    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
    {
        if (source is T[] arr)
        {
            var buffer = new T[arr.Length];
            var span = buffer.AsSpan();
            arr.CopyTo(span);
            Shuffle(span);
            
            return buffer;
        }
        else
        {
            var buffer = source.ToArray();
            Shuffle(buffer);
            return buffer;
        }
    }

    private static void Shuffle<T>(Span<T> array)
    {
        var random = RandomHelper.Random;
        for (int i = array.Length; i > 1; i--)
        {
            int j = random.Next(i);
            (array[j], array[i - 1]) = (array[i - 1], array[j]);
        }
    }
    
    public static IEnumerable<T> Random<T>(this IEnumerable<T> source, int howMany)
    {
        // ReSharper disable once PossibleMultipleEnumeration
        if (source.TryGetSpan(out var span))
        {
            var seq = RandomHelper.RandomSequenceArr(0, span.Length, howMany);
            foreach (var rand in seq)
            {
                yield return span[rand];
            }
            yield break;
        }
        
        if (source.TryGetNonEnumeratedCount(out var count))
        {
            var seq = RandomHelper.RandomSequenceArr(0, count, howMany);
            var elemNum = 0;
            foreach (var rand in seq)
            {
                // ReSharper disable once PossibleMultipleEnumeration
                foreach (var elem in source)
                {
                    if (elemNum == rand)
                        yield return elem;

                    elemNum++;
                }
            }
            yield break;
        }

        // ReSharper disable once PossibleMultipleEnumeration
        var array = source.ToArray();
        var sequence = RandomHelper.RandomSequenceArr(0, array.Length, howMany);
        foreach (var rand in sequence)
        {
            yield return array[rand];
        }
    }
}