using System.ComponentModel;
using DungeonLabMaster.Items;
using DungeonLabMaster.Items.Weapons;

namespace DungeonLabMaster;

public class MainGame
{
    public static void doStuff()
    {
   
        Map.Map mapa = new Map.Map(20, 40);
            
                
        mapa.AddItemToMap(3, 3, new Gold());
        mapa.AddItemToMap(1, 3, new Coin());
        mapa.AddWallToMap(19, 0);
        mapa.AddWallSquareToMap(3, 20, 6, 33);
        mapa.DrawStraightWallLine(1, 1, 13, 1);
        mapa.DrawStraightWallLine(4, 0, 4, 18);
        mapa.RemoveWallFromMap(5, 33);
        mapa.AddItemToMap(15, 15, new OneHandedSword());
        mapa.AddItemToMap(5, 25, new TwoHandedSword());
        mapa.AddItemToMap(4, 0, new Buckler());
        mapa.AddItemToMap(7, 0, new OneHandedSword(name: "dragon slayer"));
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
                        mapa.PlayerTryPickUpItem();
                        break;
                    case ConsoleKey.I:
                        mapa.QueryItemRemova();
                        break;
                    case ConsoleKey.Backspace:
                        keepRunning = false;
                        Console.WriteLine("thank you for using this game!");
                        break;
                    default:
                        Console.WriteLine("invalid input");
                        Thread.Sleep(5000);
                        break;
                    
                }
            }
        }
    }
}