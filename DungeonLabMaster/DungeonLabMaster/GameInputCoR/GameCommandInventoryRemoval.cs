namespace DungeonLabMaster.GameInputCoR;

public class GameCommandInventoryRemoval: GameCommandCoRBase
{
    public override bool HandleEvent(ConsoleKey pressedKey, Map.Map mapa, ref bool keepRunning)
    {
        bool doneSth = false;
        if (pressedKey == ConsoleKey.I)
        {
            mapa.QueryItemRemova();
            doneSth = true;
        }
        return doneSth | base.HandleEvent(pressedKey, mapa, ref keepRunning); 
    }
}