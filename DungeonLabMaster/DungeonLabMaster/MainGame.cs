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
            IGameCommandCoR GCOmmand_INV_INPUT = new GameCommandInvalidInput();
            IGameCommandCoR GCommand_WSAD = new GameCommandWSAD();
            IGameCommandCoR GCommand_EXIT = new GameCommandExitCall();
            IGameCommandCoR GCommand_HELP = new GameCommandHelp();
            IGameCommandCoR GCommand_INV = new GameCommandInventoryRemoval();
            IGameCommandCoR Gcommand_EQUIP = new GameCommandEquip();
            
            GCOmmand_INV_INPUT.SetNext(GCommand_WSAD);
            GCommand_WSAD.SetNext(GCommand_EXIT);
            GCommand_EXIT.SetNext(GCommand_HELP);
            GCommand_HELP.SetNext(GCommand_INV);
            GCommand_INV.SetNext(Gcommand_EQUIP);
            
            bool keepRunning = true;
            while (keepRunning)
            {
                mapa.PrintRound();
                ConsoleKey pressedKey = Console.ReadKey(true).Key;
                GCommand_WSAD.HandleEvent(pressedKey, mapa, ref keepRunning);
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