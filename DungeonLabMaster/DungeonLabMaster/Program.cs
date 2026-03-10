using DungeonLabMaster.Items;

namespace DungeonLabMaster;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Thread.Sleep(1000);
        MainGame.doStuff();
        
        Console.WriteLine("finished game. closing stuff");



    }
}