namespace DungeonLabMaster.Logging;

public class MemoryInternalLoggerType: ILoggerType
{
    private List<string> _entries = new List<string>();
    public void Log(string message, ELogCategory category, int gameTurn = -1)
    {
        if (gameTurn == -1)
        {
            _entries.Add($"[{category}] {message}");
        }
        else
        {
            _entries.Add($"[{gameTurn}][{category}] {message}");
        }
    }

    public void Flush()
    {
        ;
    }

    public List<string> GetAllEntries()
    {
        return _entries;
    }
    
    public List<string> ReturnLastNLogs(int n = -1)
    {
        if (n < 0 || n > _entries.Count)
        {
            return new List<string>(_entries);
        }
        return _entries.TakeLast(n).ToList();
    }
}