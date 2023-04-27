namespace UsefulExtensions.Core.IDictionary;

public static class IDictionaryExtensions
{
    public static T GetOrAdd<TKey, T>(this IDictionary<TKey, T> dictionary, TKey key, Func<T> factory)
    {
        if (dictionary.TryGetValue(key, out var value))
        {
            return value;
        }

        var newValue = factory();
        dictionary.Add(key, newValue);
        return newValue;
    }
    
    public static void AddOrUpdate<TKey, T>(this IDictionary<TKey, T> dictionary, TKey key, T val)
    {
        dictionary[key] = val;
    }
}