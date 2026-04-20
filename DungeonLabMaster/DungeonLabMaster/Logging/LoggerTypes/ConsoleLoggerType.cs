namespace DungeonLabMaster.Logging;

public class ConsoleLoggerType: ILoggerType
{
    public void Log(string message, ELogCategory category, int  gameTurn = -1)
    {
        if (gameTurn == -1)
        {
            Console.WriteLine($"[{category}] {message}");
        }
        else
        {
            Console.WriteLine($"[{gameTurn}][{category}] {message}");
        }
    }

    public void Flush()
    {
        ;
    }

    public List<string> ReturnLastNLogs(int n = -1)
    {
        throw new NotSupportedException();
    }
}