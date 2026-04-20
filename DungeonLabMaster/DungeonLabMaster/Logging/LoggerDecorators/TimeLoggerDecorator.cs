namespace DungeonLabMaster.Logging;

public class TimeLoggerDecorator: ALoggerTypeDecorator
{
    public TimeLoggerDecorator(ILoggerType wrapped) : base(wrapped)
    {
        ;
    }

    public override void Log(string message, ELogCategory category, int gameTurn = -1)
    {
        base.Log($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}", category, gameTurn);
    }
}