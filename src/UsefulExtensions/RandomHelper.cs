namespace UsefulExtensions;

public static class RandomHelper
{
    public static Random Random { get; set; } = new();
    
    public static IEnumerable<int> RandomSequence(int min, int max, int count)
    {
        return new RandomIterator(Random, min, max, count);
    }

    private class RandomIterator : Iterator<int>
    {
        //todo wtf fix everything
        private readonly Random _random;
        private readonly int _min;
        private readonly int _max;
        private readonly int _count;
        private readonly IEnumerator<int> _set;

        public RandomIterator(Random random, int min, int max, int count)
        {
            _random = random;
            _min = min;
            _max = max;
            _count = count;
            _set = Generate().GetEnumerator();
        }

        private List<int> Generate()
        {
            var r = new HashSet<int>(_count);
            for (int i = 0; i < _count; i++)
            {
                var n = _random.Next(_min, _max);
                if (!r.Add(n))
                    i--;
            }

            return r.Order().ToList();
        }

        public override int Current => _set.Current;

        public override bool MoveNext()
        {
            return _set.MoveNext();
        }
    }
}