namespace UsefulExtensions;

public static class TaskExtensions
{
    public static Task WhenAll(this IEnumerable<Task> tasks)
    {
        return Task.WhenAll(tasks);
    }
    
    public static Task<Task> WhenAny(this IEnumerable<Task> tasks)
    {
        return Task.WhenAny(tasks);
    }
}