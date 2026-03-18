namespace DungeonLabMaster.GameInputCoR;

public class GameCommandExitCall: GameCommandCoRBase
{
    public override bool HandleEvent(ConsoleKey pressedKey, Map.Map mapa, ref bool keepRunning)
    {
        bool doneSth = false;
        if (pressedKey == ConsoleKey.Backspace)
        {
            keepRunning = false;
            doneSth = true;
        }

        return doneSth | base.HandleEvent(pressedKey, mapa, ref keepRunning);
        }
}