namespace UsefulExtensions;

public class BloomFilter<T> : BloomFilter
{
    private const int DefaultSize = 64;
    public BloomFilter(int size = DefaultSize) : base(size)
    { }
}

public class BloomFilter
{
    private readonly byte[] _buffer;

    public BloomFilter(int size)
    {
        _buffer = new byte[size];
    }

    public void Add(byte[] element)
    {
        if (_buffer.Length != element.Length)
            throw new InvalidOperationException();

        for (int i = 0; i < _buffer.Length; i++)
        {
            _buffer[i] = (byte) (_buffer[i] | element[i]);
        }
    }

    public bool MaybeBelong(byte[] element)
    {
        if (_buffer.Length != element.Length)
            throw new InvalidOperationException();
            
        var may = true;
        for (int i = 0; i < _buffer.Length; i++)
        {
            if (element[i] == 0)
                continue;

            may &= (byte) (~_buffer[i] | element[i]) == byte.MaxValue;
        }

        return may;
    }
}