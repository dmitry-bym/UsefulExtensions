using System.Collections;
using System.Numerics;

namespace UsefulExtensions;

internal static class RangeHelper
{
    internal static Iterator<T> Range<T>(T start, T end) where T : INumber<T>
    {
        return new RangeIterator<T>(start, end, T.One);
    }
    
    internal static Iterator<T> Range<T>(T start, T end, T step) where T : INumber<T>
    {
        return new RangeIterator<T>(start, end, step);
    }

    private class RangeIterator<T> : Iterator<T> where T : INumber<T>
    {
        private readonly T _start;
        private readonly T _end;
        private readonly T _step;
        private T _innerCurrent;
        
        public RangeIterator(T start, T end, T step)
        {
            _start = start;
            _end = end;
            _step = step;
            _innerCurrent = start;
        }
        
        public override bool MoveNext()
        {
            //if _start == _end return false
            if (_start >= _end && _innerCurrent <= _end)
                return false;

            if (_start < _end && _innerCurrent >= _end)
                return false;
            
            Current = _innerCurrent;
            _innerCurrent += _step;
            return true;
        }
    }
    
}