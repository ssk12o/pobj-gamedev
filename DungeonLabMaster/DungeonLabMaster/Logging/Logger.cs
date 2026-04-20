namespace DungeonLabMaster.Logging;

public sealed class Logger
{
    private static readonly Lazy<Logger> _instance = new(() => new Logger());
    public static Logger Instance => _instance.Value;
    private List<ILoggerType> _loggerTypes;
    
    private Logger()
    {
        _loggerTypes = new List<ILoggerType>();
        _loggerTypes.Add(new MemoryInternalLoggerType());
    }

    public void SetStrategy(ILoggerType loggerType)
    {
        _loggerTypes = new List<ILoggerType>();
        _loggerTypes.Add(loggerType);
    }

    public void AddStrategy(ILoggerType loggerType)
    {
        _loggerTypes.Add(loggerType);
    }

    public void Log(string message, ELogCategory cat = ELogCategory.Other)
    {
        foreach (var loggerType in _loggerTypes)
        {
            loggerType.Log(message, cat);
        }
    }

    public List<string> ReturnLastNLogs(int n = -1)
    {
        return _loggerTypes[0].ReturnLastNLogs(n);
    }

    public void Flush()
    {
        foreach (var loggerType in _loggerTypes)
        {
            loggerType.Flush();
        }
    }
}