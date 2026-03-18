using System.ComponentModel;

namespace DungeonLabMaster.GameInputCoR;

public class GameCommandCoRBase: IGameCommandCoR
{
    IGameCommandCoR? _next = null;


    public virtual bool HandleEvent(ConsoleKey pressedKey, Map.Map mapa, ref bool keepRunning)
    {
        if (_next != null)
        {
            return _next.HandleEvent(pressedKey, mapa, ref keepRunning);
        }
        return false;
    }

    public void SetNext(IGameCommandCoR next)
    {
        if (_next != null)
        {
            throw new InvalidEnumArgumentException();
        }

        _next = next;
    }
}