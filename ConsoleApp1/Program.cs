// See https://aka.ms/new-console-template for more information

using UsefulExtensions;

var a = new[] {(12m, 12m), (4m, 4m)};
var b = a.Average(x => x.Item1, x => x.Item2);
Console.WriteLine(b);