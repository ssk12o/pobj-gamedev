namespace DungeonLabMaster.Logging;

public abstract class ALoggerTypeDecorator: ILoggerType
{
    protected ILoggerType _wrapped;

    public ALoggerTypeDecorator(ILoggerType wrapped)
    {
        _wrapped = wrapped;
    }
    
    
    public virtual void  Log(string message, ELogCategory category, int gameTurn = -1)
    {
        _wrapped.Log(message, category, gameTurn);
    }
    public List<string> ReturnLastNLogs(int n = -1)
    {
        return _wrapped.ReturnLastNLogs(n);
    }
    public virtual void Flush()
    {
        _wrapped.Flush();
    }
}