using DungeonLabMaster.GameInputCoR;
using DungeonLabMaster.Items;
using DungeonLabMaster.Items.Weapons;
using DungeonLabMaster.Items.Weapons.OrdinaryItems;
using DungeonLabMaster.Map;

namespace DungeonLabMaster;

public class MainGame
{
    public static void RunGame()
    {
        List<IDungeonStrategy> automaticBuildingStrategies = new List<IDungeonStrategy>
        {
            new DungeonStrategyManual(), new DungeonStrategyClassic(), new DungeonStrategyLab(), new DungeonStrategyMapArena()
        };
        Console.WriteLine("Preparing the game...");
        Console.WriteLine("Choose a way to build dungeon:");
        for(int i = 0; i < automaticBuildingStrategies.Count; i++)
        {
            Console.WriteLine($"[{i}] - {automaticBuildingStrategies[i]}");
        }
        
        int dungeonChoice;
        while(!int.TryParse(Console.ReadLine(), out dungeonChoice)|| dungeonChoice < 0 || dungeonChoice > automaticBuildingStrategies.Count)
        {
            Console.WriteLine("Invalid option. try again.");
            Thread.Sleep(1000);
        }
        IDungeonMapBuilder mapBuilder = new DungeonMapBuilder();
        automaticBuildingStrategies[dungeonChoice].Construct(mapBuilder);
        
        
        Map.Map mapa = mapBuilder.GetMap();
        WelcomeMessage();
        EventLoop(mapa);
        
        void EventLoop(Map.Map mapa)
        {
            IGameCommandCoR lGCommandInvInput = new GameCommandInvalidInput();
            IGameCommandCoR lGCommandWsad = new GameCommandWsad();
            IGameCommandCoR lGCommandExit = new GameCommandExitCall();
            IGameCommandCoR lGCommandHelp = new GameCommandHelp();
            IGameCommandCoR lGCommandInv = new GameCommandInventoryRemoval();
            IGameCommandCoR lGcommandEquip = new GameCommandEquip();
            
            lGCommandInvInput.SetNext(lGCommandWsad);
            lGCommandWsad.SetNext(lGCommandExit);
            lGCommandExit.SetNext(lGCommandHelp);
            lGCommandHelp.SetNext(lGCommandInv);
            lGCommandInv.SetNext(lGcommandEquip);
            
            bool keepRunning = true;
            while (keepRunning)
            {
                mapa.PrintRound();
                ConsoleKey pressedKey = Console.ReadKey(true).Key;
                lGCommandWsad.HandleEvent(pressedKey, mapa, ref keepRunning);
                if (!mapa.playerIsAlive)
                {
                    keepRunning = false;
                    Console.WriteLine("\n\nGame over!!!\n\n");
                }
            }
        }

        void WelcomeMessage()
        {
            Console.Clear();
            Console.WriteLine("Map generated. starting!");
            Console.WriteLine("Welcome to DungeonLabMaster!");
            Console.WriteLine("Bla bla bal");
            Console.WriteLine("press any key to continue...");
            ConsoleKey pressed = Console.ReadKey(true).Key;
        }
    }
}