namespace DungeonLabMaster.SoundPropagation;

public class SoundNotification: INotification
{
    public int sourceX { get; }
    public int sourceY { get; }
    public int NoiseLevel { get; }
    public int Distance { get; set; }


    public SoundNotification(int X, int Y, int noiseLevel)
    {
        sourceX = X;
        sourceY = Y;
        NoiseLevel = noiseLevel;
    }
}