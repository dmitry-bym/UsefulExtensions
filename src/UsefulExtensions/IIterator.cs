using System.Collections;

namespace UsefulExtensions;

internal abstract class Iterator<T> : IEnumerator<T>, IEnumerable<T>
{
    public abstract bool MoveNext();

    public void Reset()
    {
        throw new NotSupportedException();
    }

    public virtual T? Current { get; protected set; }

    object? IEnumerator.Current => Current;

    public virtual void Dispose()
    { }

    public IEnumerator<T> GetEnumerator()
    {
        return this;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}