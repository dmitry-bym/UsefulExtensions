// See https://aka.ms/new-console-template for more information


using UsefulExtensions;
using UsefulExtensions.AwaitableTuple;

var (smth1, s2, smth3, smth4, smth5, smth6) = await (
    DoSmth(), 
    DoSmth(), 
    DoSmth(), 
    DoSmth(), 
    DoSmth(), 
    DoSmth()
    ).WhenAll();


Task<int> DoSmth()
{
    return Task.CompletedTask;
}