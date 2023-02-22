// See https://aka.ms/new-console-template for more information

using MoreLinq.Extensions;
using UsefulExtensions;

var a = Enum();

IEnumerable<int> a;
a.Batch( )




async IAsyncEnumerable<string> Enum()
{
    await Task.Delay(1000);
    yield return "str 1";
    await Task.Delay(1000);
    yield return "str 2";
    await Task.Delay(1000);
    yield return "str 3";
}


