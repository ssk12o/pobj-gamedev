using DungeonLabMaster.GameInputCoR;
using DungeonLabMaster.Items;
using DungeonLabMaster.Items.Weapons;
using DungeonLabMaster.Items.Weapons.OrdinaryItems;

namespace DungeonLabMaster;

public class MainGame
{
    public static void RunGame()
    {
   
        Map.Map mapa = new Map.Map(20, 40);
            
                
        mapa.AddItemToMap(3, 3, new Gold());
        mapa.AddItemToMap(1, 3, new Coin());
        mapa.AddWallToMap(19, 0);
        mapa.DrawWallSquareToDungeonMap(3, 20, 6, 33);
        mapa.DrawWallStrightLIneToDungeonMap(1, 1, 13, 1);
        mapa.DrawWallStrightLIneToDungeonMap(4, 0, 4, 18);
        mapa.DrawWallSquareToDungeonMap(15, 12, 19, 30);
        mapa.DrawWallStrightLIneToDungeonMap(7, 13, 38, 13);
        mapa.DrawRemoveWallTileFromMap(5, 33);
        mapa.AddItemToMap(19, 35, new BigRock());
        mapa.AddItemToMap(19, 34, new Rock());
        mapa.AddItemToMap(19, 33, new Torch(20));
        mapa.AddItemToMap(15, 15, new OneHandedSword());
        mapa.AddItemToMap(5, 25, new TwoHandedSword());
        mapa.AddItemToMap(4, 0, new Buckler());
        mapa.AddItemToMap(7, 0, new OneHandedSword(name: "Dragon slayer"));
        
        
        Thread.Sleep(1000);
        WelcomeMessage();
        EventLoop();
        
        
        void EventLoop()
        {
            IGameCommandCoR lGCommand_INV_INPUT = new GameCommandInvalidInput();
            IGameCommandCoR lGCommand_WSAD = new GameCommandWSAD();
            IGameCommandCoR lGCommand_EXIT = new GameCommandExitCall();
            IGameCommandCoR lGCommand_HELP = new GameCommandHelp();
            IGameCommandCoR lGCommand_INV = new GameCommandInventoryRemoval();
            IGameCommandCoR lGcommand_EQUIP = new GameCommandEquip();
            
            lGCommand_INV_INPUT.SetNext(lGCommand_WSAD);
            lGCommand_WSAD.SetNext(lGCommand_EXIT);
            lGCommand_EXIT.SetNext(lGCommand_HELP);
            lGCommand_HELP.SetNext(lGCommand_INV);
            lGCommand_INV.SetNext(lGcommand_EQUIP);
            
            bool keepRunning = true;
            while (keepRunning)
            {
                mapa.PrintRound();
                ConsoleKey pressedKey = Console.ReadKey(true).Key;
                lGCommand_WSAD.HandleEvent(pressedKey, mapa, ref keepRunning);
            }
        }

        void WelcomeMessage()
        {
            Console.WriteLine("Map generated. starting!");
            Console.WriteLine("Welcome to DungeonLabMaster!");
            Console.WriteLine("Bla bla bal");
            Console.WriteLine("press any key to continue...");
            ConsoleKey pressed = Console.ReadKey(true).Key;
        }
    }
}