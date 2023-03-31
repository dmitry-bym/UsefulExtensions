namespace UsefulExtensions;

internal interface IIterator<out T> : IEnumerator<T>, IEnumerable<T>
{
    
}