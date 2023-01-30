// See https://aka.ms/new-console-template for more information

using UsefulExtensions;

var arr = new[] { new ClassA(1), new ClassA(2)};
var a = new[] { new ClassB(1) , new ClassB(3)};
var joinResult = arr.Join(a, x => x.id, x => x.id, (i, d) => (i, d));
var leftJoinResult = arr.LeftJoin(a, x => x.id, x => x.id, (i, d) => (i, d));
var rightJoinResult = arr.RightJoin(a, x => x.id, x => x.id, (i, d) => (i, d));

arr.Average(x => x.id, x => x.id)

Console.WriteLine("===========Join===========");
foreach(var item in joinResult)
{
    Console.WriteLine(item);
}

Console.WriteLine("===========Left join===========");
foreach(var item in leftJoinResult)
{
    Console.WriteLine(item);
}
Console.WriteLine("===========Right join===========");
foreach(var item in rightJoinResult)
{
    Console.WriteLine(item);
}


public record ClassA(int id);

public record ClassB(int id);


