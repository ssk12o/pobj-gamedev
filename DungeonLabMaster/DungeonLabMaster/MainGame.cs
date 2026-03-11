using System.ComponentModel;
using System.Xml.Schema;
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
        Console.WriteLine("Map generated. starting!");
        Thread.Sleep(1000);
        
        EventLoop();
        
        
        void EventLoop()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                mapa.PrintRound();
                ConsoleKey pressedKey = Console.ReadKey(true).Key;
                switch (pressedKey)
                {
                    case ConsoleKey.A:
                        mapa.TryMoveMainPlayer(0, -1);
                        break;
                    case ConsoleKey.D:
                        mapa.TryMoveMainPlayer(0, 1);
                        break;
                    case ConsoleKey.W:
                        mapa.TryMoveMainPlayer(-1, 0);
                        break;
                    case ConsoleKey.S:
                        mapa.TryMoveMainPlayer(1, 0);
                        break;
                    case ConsoleKey.E:
                        if (!mapa.PlayerTryPickUpItem())
                        {
                            mapa.PlayerPrintEquipmentLong();
                            WaitForInput();
                        };
                        break;
                    case ConsoleKey.I:
                        mapa.QueryItemRemova();
                        break;
                    case ConsoleKey.Backspace:
                        keepRunning = false;
                        Console.WriteLine("thank you for using this game!");
                        break;
                    case ConsoleKey.H:
                        Console.Clear();
                        PrintMenuOptions();
                        WaitForInput();
                        break;
                    default:
                        Console.WriteLine("invalid input");
                        Thread.Sleep(5000);
                        break;
                    
                }
            }
        }

        void WaitForInput()
        {
            Console.WriteLine("press any key to continue...");
            ConsoleKey pressed = Console.ReadKey(true).Key;
        }
        void PrintMenuOptions()
        {
            Console.Write("Welcome in help menu. Options:\n" +
                          "\t - WSAD to move\n"+
                          "\t - E to equip item (if possible) or print items in inventory\n"+
                          "\t - I to remove item from equipment\n" +
                          "\t - Backspace to exit game\n"+
                          "\t - H to enter this menu\n");
        }
    }
}