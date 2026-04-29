using DungeonLabMaster.Items;
using DungeonLabMaster.Items.Weapons;
using DungeonLabMaster.Logging;
using DungeonLabMaster.SoundPropagation;

namespace DungeonLabMaster.MovableEntities.Enemy;

public class Enemy: IObserverSubscriber, IAliveEntity
{
    public IItem weapon { get; protected set; }
    public int attack { get; protected set; }
    public int Armor {get; }
    public string Name { get; }
    public char MapChar { get; }
    public IAliveEntity.PlayerStatsT Playerstats { get; }
    public int PosX { get; set; }
    public int PosY { get; set; }
    private Map.Map gameMapRef;

    public void SubscribeAll()
    {
        // #if debug
        Console.WriteLine("subscribing");
        // #endif?
        SoundSingleton.Instance.Emitter.AddObserver(this);
        EnemyDeathSingleton.Instance.GetEmmiter(Name).AddObserver(this);
    }
    public void UnsubscribeAll()
    {
        SoundSingleton.Instance.Emitter.RemoveObserver(this);
        EnemyDeathSingleton.Instance.GetEmmiter(Name).RemoveObserver(this);
    }

    public virtual void OnNotify(INotification notification)
    {
        // Logger.Instance.Log("enemy processes sound");
        if (notification is SoundNotification sondNotification)
        {
            if (Pathfinding.CanReach(notification.sourceX, notification.sourceY, PosX, PosY,
                    sondNotification.NoiseLevel, gameMapRef))

            {
                sondNotification.Distance = Pathfinding.CalculateDistance(notification.sourceX, notification.sourceY, PosX, PosY, gameMapRef);
                Logger.Instance.Log($"Enemy {Name} at {PosX},{PosY}: hears player make sound at {sondNotification.Distance}/{sondNotification.NoiseLevel}", ELogCategory.SoundInfo);
            }
        } 
        else if (notification is DeathNotification deathNotification)
        {
            Logger.Instance.Log($"Enemy {Name} at {PosX},{PosY}: hear their mate die at {deathNotification.sourceX}, {deathNotification.sourceY}", ELogCategory.SoundInfo);
        }
        else
        {
            throw new Exception("wrong notification type");
        }
    }
    public Enemy(int y, int x, IItem weapn,  string myName,int hp = 10)
    {
        PosY = y;
        PosX = x;
        weapon = weapn;
        Playerstats = new IAliveEntity.PlayerStatsT();
        Playerstats.Health = Playerstats.MaxHealth = hp;
        Armor = 2;
        Name = myName;
        MapChar = Name[0];
        SubscribeAll();
    }

    public void addMapRef(Map.Map map)
    {
        gameMapRef = map;
    }
    public bool Move(int y, int x)
    {
        if (gameMapRef.CheckIfTileIsReachable(PosY + y, PosX + x))
        {
            PosY += y;
            PosX += x;
            return true;
        }
        
        return false;
    }

    public bool MoveRandom()
    {
        int[] mv = { -1, 1 };
        return Move(mv[Random.Shared.Next(mv.Length)], mv[Random.Shared.Next(mv.Length)]);
    }

    public int CalculateAttackDamage(IWeaponVisitor vis)
    {
        int h = 0;
        
        var _weapon = weapon as IWeapon;
        if (_weapon != null && weapon.IsWeapon)
        {
            h = _weapon.Accept(vis);
        }
        
        // return Math.Max(0, h);
        // TODO: tmp for demonstration purposes
        return 25;
    }
}