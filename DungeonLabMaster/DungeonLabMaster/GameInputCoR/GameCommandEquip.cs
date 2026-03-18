using DungeonLabMaster.GameInputCoR;
using DungeonLabMaster.Map;

public class GameCommandEquip : GameCommandCoRBase
{
    public override bool HandleEvent(ConsoleKey pressedKey, Map mapa, ref bool keepRunning)
    {
        bool doneSth = false;
        if (pressedKey == ConsoleKey.E)
        {
            if (!mapa.PlayerTryPickUpItem())
            {
                mapa.PlayerPrintEquipmentLong();
                WaitForInput();
            }
            doneSth = true;
        }

        return doneSth | base.HandleEvent(pressedKey, mapa, ref keepRunning);
    }

    void WaitForInput()
    {
        Console.WriteLine("press any key to continue...");
        ConsoleKey pressed = Console.ReadKey(true).Key;
    }
}





                  
                    
