using DungeonLabMaster.Items;
using DungeonLabMaster.Items.Weapons;
using DungeonLabMaster.Logging;
using DungeonLabMaster.MovableEntities.Enemy.enemyDeathTriggers;
using DungeonLabMaster.SoundPropagation;

namespace DungeonLabMaster.MovableEntities.Enemy;

public class Enemy: IObserverSubscriber, IAliveEntity
{
    public IItem weapon { get; protected set; }
    public int attack { get; protected set; }
    public int Armor {get; }
    public string Name { get; protected set; }
    public char MapChar { get; }
    public IAliveEntity.PlayerStatsT Playerstats { get; private set; }
    private bool deathEnemy = false;
    private IenemyDeathTrigger _deathEnemyTypeTrigger { get; }

    public void mateDied()
    {
        if (!deathEnemy && _deathEnemyTypeTrigger != null)
        {
            Logger.Instance.Log($"{Name} becomes {_deathEnemyTypeTrigger.GetTriggerText()}", ELogCategory.CombatInfo);
            Name = $"{_deathEnemyTypeTrigger.GetTriggerText()}";
            Playerstats += _deathEnemyTypeTrigger.getStatsChagne();
            deathEnemy  = true;
        }
    }
    public int PosX { get; set; }
    public int PosY { get; set; }
    private Map.Map gameMapRef;

    public void SubscribeAll()
    {
        // Console.WriteLine("subscribing");
        SoundSingleton.Instance.Emitter.AddObserver(this);
        
        // Console.WriteLine("unsubscribing deatg, counts");
        // Console.WriteLine(EnemyDeathSingleton.Instance.GetEmmiter(Name).GetObserverCount());
        EnemyDeathSingleton.Instance.GetEmmiter(Name).AddObserver(this);
        // Console.WriteLine(EnemyDeathSingleton.Instance.GetEmmiter(Name).GetObserverCount());

    }
    public void UnsubscribeAll()
    {
        SoundSingleton.Instance.Emitter.RemoveObserver(this);
        EnemyDeathSingleton.Instance.GetEmmiter(Name).RemoveObserver(this);
        
        // DEBUG INFO
        // Console.WriteLine("unsubscribing sound, counts");
        // Console.WriteLine(SoundSingleton.Instance.Emitter.GetObserverCount());
        // Console.WriteLine(SoundSingleton.Instance.Emitter.GetObserverCount());
        // Console.WriteLine("unsubscribing sound, end");
        //
        // Console.WriteLine("unsubscribing deatg, counts");
        // Console.WriteLine(EnemyDeathSingleton.Instance.GetEmmiter(Name).GetObserverCount());
        // Console.WriteLine(EnemyDeathSingleton.Instance.GetEmmiter(Name).GetObserverCount());
        // Console.WriteLine("unsubscribing death, end");

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
            mateDied();
            Logger.Instance.Log($"Enemy {Name} at {PosX},{PosY}: hear their mate die at ({deathNotification.sourceY}, {deathNotification.sourceX})", ELogCategory.SoundInfo);
        }
        else
        {
            throw new Exception("wrong notification type");
        }
    }
    public Enemy(int y, int x, IItem weapn,  string myName,int hp = 10, IenemyDeathTrigger trigger =  null)
    {
        PosY = y;
        PosX = x;
        weapon = weapn;
        Playerstats = new IAliveEntity.PlayerStatsT();
        Playerstats.Health = Playerstats.MaxHealth = hp;
        Armor = 2;
        Name = myName;
        MapChar = Name[0];
        _deathEnemyTypeTrigger  = trigger;
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