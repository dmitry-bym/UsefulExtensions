// See https://aka.ms/new-console-template for more information

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using UsefulExtensions;

BenchmarkRunner.Run<Md5VsSha256>();

[MemoryDiagnoser]
public class Md5VsSha256
{
    private User[] data;


    enum TestEnum
    {
        None, 
        Test
    }
    [Params(100)]
    public int N;
    
    [GlobalSetup]
    public void Setup()
    { }

    [Benchmark]
    public void For()
    {
        for (int i = 0; i < data.Length; i++)
        {
            Do(data[i]);
        }
    }
    
    [Benchmark]
    public void ForFast()
    {
        TestEnum.Test.ToString();
    }

    public record User(string Name);

    public void Do(User user)
    {
    }
}