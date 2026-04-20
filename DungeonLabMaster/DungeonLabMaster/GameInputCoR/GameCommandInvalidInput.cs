using DungeonLabMaster.Logging;

namespace DungeonLabMaster.GameInputCoR;

public class GameCommandInvalidInput: GameCommandCoRBase
{
    public override bool HandleEvent(ConsoleKey pressedKey, Map.Map mapa, ref bool keepRunning)
    {
        if (!base.HandleEvent(pressedKey, mapa, ref keepRunning))
        {
            Logger.Instance.Log("Player made invalid move", ELogCategory.GameInputInfo);
            Console.WriteLine("invalid input");
            Thread.Sleep(5000);
        }
        return true;
    }
}