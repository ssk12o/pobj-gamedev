namespace DungeonLabMaster.SoundPropagation;

public sealed class EnemyDeathSingleton
{
    private static readonly Lazy<EnemyDeathSingleton> _instance = new(() => new EnemyDeathSingleton());
    
    private readonly Dictionary<string, DeathEmitter> _channels = new Dictionary<string, DeathEmitter>();
    
    public static EnemyDeathSingleton Instance => _instance.Value;

    private EnemyDeathSingleton()
    {
        ;
    }

    public DeathEmitter GetEmmiter(string enemyName)
    {
        if (!_channels.ContainsKey(enemyName))
        {
            _channels[enemyName] = new DeathEmitter(enemyName);
        }

        return _channels[enemyName];
    }
}