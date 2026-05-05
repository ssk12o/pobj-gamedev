using DungeonLabMaster.DungeonThemes;
using DungeonLabMaster.GameInputCoR;
using DungeonLabMaster.Items;
using DungeonLabMaster.Items.Weapons;
using DungeonLabMaster.Items.Weapons.OrdinaryItems;
using DungeonLabMaster.Logging;
using DungeonLabMaster.Map;

namespace DungeonLabMaster;

public class MainGame
{
    public static void RunGame()
    {
        var config = ConfigFasade.Load("game_config.json");
        var logPath = LogFileFactory.CreateUniqueLogPath(config.LogFilePath, config.PlayerName);
        
        var fileLogger = new FileLoggerType(logPath);
        var memoryLogger = new MemoryInternalLoggerType();
        
        Logger.Instance.AddStrategy(new TimeLoggerDecorator(fileLogger));
        Logger.Instance.AddStrategy(memoryLogger);

        Logger.Instance.Log($"Starting game. Player name is {config.PlayerName}", ELogCategory.Other);
        Logger.Instance.Log($"Started game theme is set to {config.DungeonName}", ELogCategory.Other);

        var theme = ThemeFactory.GetTheme(config.DungeonName);
        Logger.Instance.Log(theme.ThemeIntroductionMessage, ELogCategory.Other);

        Map.Map mapa = theme.getMap();
        
        WelcomeMessage();
        EventLoop(mapa);
        
        Logger.Instance.Log("Game ended", ELogCategory.Other);
        Logger.Instance.Flush();
        Console.WriteLine("Game ended");
        
        
        void EventLoop(Map.Map mapa)
        {
            IGameCommandCoR lGCommandInvInput = new GameCommandInvalidInput();
            IGameCommandCoR lGCommandWsad = new GameCommandWsad();
            IGameCommandCoR lGCommandExit = new GameCommandExitCall();
            IGameCommandCoR lGCommandHelp = new GameCommandHelp();
            IGameCommandCoR lGCommandInv = new GameCommandInventoryRemoval();
            IGameCommandCoR lGcommandEquip = new GameCommandEquip();
            IGameCommandCoR lGCommandPrintLogs = new GameCommandPrintLogs();
            
            lGCommandInvInput.SetNext(lGCommandWsad);
            lGCommandWsad.SetNext(lGCommandExit);
            lGCommandExit.SetNext(lGCommandHelp);
            lGCommandHelp.SetNext(lGCommandInv);
            lGCommandInv.SetNext(lGcommandEquip);
            lGcommandEquip.SetNext(lGCommandPrintLogs);
            
            bool keepRunning = true;
            while (keepRunning)
            {
                mapa.PrintRound();
                ConsoleKey pressedKey = Console.ReadKey(true).Key;
                lGCommandInvInput.HandleEvent(pressedKey, mapa, ref keepRunning);
                if (!mapa.playerIsAlive)
                {
                    keepRunning = false;
                    Console.WriteLine("\n\nGame over!!!\n\n");
                    Logger.Instance.Log($"Game over. Player lost", ELogCategory.Other);
                    Logger.Instance.Flush();
                }
            }
        }

        void WelcomeMessage()
        {
            Console.Clear();
            Console.WriteLine("Map generated. starting!");
            Console.WriteLine("Welcome to DungeonLabMaster!");
            Console.WriteLine("press any key to continue...");
            ConsoleKey pressed = Console.ReadKey(true).Key;
        }
    }
}