namespace DungeonLabMaster.GameInputCoR;

public class GameCommandHelp: GameCommandCoRBase
{
    public override bool HandleEvent(ConsoleKey pressedKey, Map.Map mapa, ref bool keepRunning)
    {
        bool doneSth = false;

        if (pressedKey == ConsoleKey.H)
        {
            Console.Clear();
            PrintMenuOptions();
            WaitForInput();
            doneSth = true;
        }

        return doneSth | base.HandleEvent(pressedKey, mapa, ref keepRunning);

        void WaitForInput()
        {
            Console.WriteLine("press any key to continue...");
            ConsoleKey pressed = Console.ReadKey(true).Key;
        }

        void PrintMenuOptions()
        {
            
            Console.Write("Welcome in help menu. Options:\n");
            foreach (string msg in mapa.HelpTextList)
            {
                Console.WriteLine(msg);
            }
            // Console.Write("Welcome in help menu. Options:\n" +
            //               "\t - WSAD to move\n" +
            //               "\t - E to equip item (if possible) or print long items in inventory\n" +
            //               "\t - I to remove item from equipment\n" +
            //               "\t - Backspace to exit game\n" +
            //               "\t - H to enter this menu\n");
        }
    }
}