namespace DungeonLabMaster.GameInputCoR;

public class GameCommandInvalidInput: GameCommandCoRBase
{
    public override bool HandleEvent(ConsoleKey pressedKey, Map.Map mapa, ref bool keepRunning)
    {
        if (!base.HandleEvent(pressedKey, mapa, ref keepRunning))
        {
            Console.WriteLine("invalid input");
            Thread.Sleep(5000);
        }
        return true;
    }
}