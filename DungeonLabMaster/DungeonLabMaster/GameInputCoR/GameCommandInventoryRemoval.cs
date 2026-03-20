namespace DungeonLabMaster.GameInputCoR;

public class GameCommandInventoryRemoval: GameCommandCoRBase
{
    public override bool HandleEvent(ConsoleKey pressedKey, Map.Map mapa, ref bool keepRunning)
    {
        bool doneSth = false;
        if (pressedKey == ConsoleKey.I)
        {
            mapa.QueryItemRemoval();
            doneSth = true;
        }
        return doneSth | base.HandleEvent(pressedKey, mapa, ref keepRunning); 
    }
}