namespace DungeonLabMaster.GameInputCoR;

public class GameCommandWsad: GameCommandCoRBase
{
    public override bool HandleEvent(ConsoleKey pressedKey, Map.Map mapa, ref bool keepRunning)
    {
        bool doneSth = false;
        switch (pressedKey)
        {
            case ConsoleKey.A:
                doneSth = true;
                mapa.TryMoveMainPlayer(0, -1);
                break;
            case ConsoleKey.D:
                doneSth = true;
                mapa.TryMoveMainPlayer(0, 1);
                break;
            case ConsoleKey.W:
                doneSth = true;
                mapa.TryMoveMainPlayer(-1, 0);
                break;
            case ConsoleKey.S:
                doneSth = true;
                mapa.TryMoveMainPlayer(1, 0);
                break;

            
        }

            return doneSth | base.HandleEvent(pressedKey, mapa, ref keepRunning);
    }
}