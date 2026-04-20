using DungeonLabMaster.Items;

namespace DungeonLabMaster;

class Program
{
    static void Main(string[] args)
    {
        MainGame.RunGame();
        Console.Clear();
        Console.WriteLine("Game finished! bye!");
    }
}