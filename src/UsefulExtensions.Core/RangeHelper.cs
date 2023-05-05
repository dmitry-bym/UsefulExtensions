using System.Numerics;

namespace UsefulExtensions.Core;

public static class RangeHelper
{
    public static Iterator<T> Range<T>(T start, int count) where T : INumber<T>
    {
        return new RangeIterator<T>(start, count, T.One);
    }
    
    public static Iterator<T> Range<T>(T start, int count, T step) where T : INumber<T>
    {
        return new RangeIterator<T>(start, count, step);
    }

    private class RangeIterator<T> : Iterator<T> where T : INumber<T>
    {
        private int _count;
        private readonly T _step;
        private T _innerCurrent;
        
        public RangeIterator(T start, int count, T step)
        {
            _count = count;
            _step = step;
            _innerCurrent = start;
        }
        
        public override bool MoveNext()
        {
            if (_count == 0)
                return false;
            
            Current = _innerCurrent;
            _innerCurrent += _step;
            _count--;
            return true;
        }
    }
    
}