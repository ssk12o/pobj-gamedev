using DungeonLabMaster.Logging;

namespace DungeonLabMaster.GameInputCoR;

public class GameCommandPrintLogs: GameCommandCoRBase
{
    public override bool HandleEvent(ConsoleKey pressedKey, Map.Map mapa, ref bool keepRunning)
    {
        bool doneSth = false;
        if (pressedKey == ConsoleKey.P)
        { 
            doneSth = true;

            var list = Logger.Instance.ReturnLastNLogs();
            
            Console.Clear();
            Console.WriteLine($"All game logs. {list.Count} entries returned.");
            foreach (var entry in list)
            {
                Console.WriteLine(entry);
            }
            
            Console.WriteLine("press any key to continue...");
            ConsoleKey pressed = Console.ReadKey(true).Key;
        }

        return doneSth | base.HandleEvent(pressedKey, mapa, ref keepRunning);
    }
}