namespace DungeonLabMaster.GameInputCoR;

public interface IGameCommandCoR
{
    bool HandleEvent(ConsoleKey pressedKey, Map.Map mapa, ref bool keepRunning);
    void SetNext(IGameCommandCoR next);
}