namespace DungeonLabMaster.SoundPropagation;

public class DeathNotification: INotification
{
    public int sourceX { get; }
    public int sourceY { get; }
    public string DeadName { get; }
    
    public DeathNotification(int X, int Y, string name)
    {
        sourceX = X;
        sourceY = Y;
        DeadName = name;
    }
}