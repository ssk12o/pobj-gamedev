namespace DungeonLabMaster.Logging;

public interface ILoggerType
{
    void Log(string message, ELogCategory category, int gameTurn = -1);
    public List<string> ReturnLastNLogs(int n = -1);
    void Flush();
}