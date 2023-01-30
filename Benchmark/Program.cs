// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using UsefulExtensions;

BenchmarkRunner.Run<Md5VsSha256>();

public class Md5VsSha256
{
    private const int N = 10000;
    private readonly TestData[] data;

    public Md5VsSha256()
    {
        var random = new Random();
        data = new TestData[N];
        for (int i = 0; i < N; i++)
        {
            var num1 = (decimal)random.NextDouble();
            var num2 = (decimal)random.NextDouble();
            var num3 = (decimal)random.NextDouble();
            var num4 = (decimal)random.NextDouble();
            data[i] = new TestData(num1, num2, num3, num4);
        }
    }
    [Benchmark]
    public (decimal, decimal, decimal, decimal) AverageStandard() => (data.Average(x => x.Value1), data.Average(x => x.Value2), data.Average(x => x.Value3), data.Average(x => x.Value4));

    [Benchmark]
    public (decimal, decimal, decimal, decimal) AverageUseful() => data.Average(x => x.Value1, x => x.Value2, x => x.Value3, x => x.Value4);

    public record TestData(decimal Value1, decimal Value2, decimal Value3, decimal Value4);
}