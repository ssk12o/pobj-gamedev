namespace DungeonLabMaster.SoundPropagation;

public class SoundSingleton
{
    private static readonly Lazy<SoundSingleton> _instance = new(() => new SoundSingleton());
    private SoundEmitter _emitter;
    public static SoundSingleton Instance => _instance.Value;
    private SoundSingleton()
    {
        _emitter =  new SoundEmitter();
    }
    
    public SoundEmitter Emitter => _emitter;
}