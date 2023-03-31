// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using UsefulExtensions;
using UsefulExtensions.AwaitableTuple;

BenchmarkRunner.Run<Md5VsSha256>();

[MemoryDiagnoser]
public class Md5VsSha256
{
    private const int N = 10000;


    private (int, int) data;
    
    [Params(100, 10_000, 100_000_000)]
    public int dataTo;
    
    [GlobalSetup]
    public void Setup()
    {
        data = (0, dataTo);
    }

    [Benchmark]
    public void Range()
    {
        var enumerable = data.Range();
        foreach (var d in enumerable)
        {
            Do(d);
        }
    }

    [Benchmark]
    public void EnumRange()
    {
        var enumerable = Enumerable.Range(data.Item1, data.Item2);
        foreach (var d in enumerable)
        {
            Do(d);
        }
    }

    public void Do(int d) {}
}