using DungeonLabMaster.MovableEntities;

namespace DungeonLabMaster.Items.Weapons;

public class LightWeapon: IWeapon, IItem
{
    public int GetDamage(IAliveEntity.PlayerStatsT playerStats)
    {
        return Damage;
    }

    public int Damage { get; protected set; }
    public int Defense { get;  protected set;}
    public int Handness { get; } = 1;
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public char ItemMapName { get;  protected set;}
    public bool IsWeapon { get;  protected set;} =  true;

    public int Accept(IWeaponVisitor visitor) => visitor.Visit(this);
    
    public string GetCategoryOfWeapon() => "Light";
    
    public int GetDefenseForNormalAttack(IAliveEntity.PlayerStatsT stats)
    {
        return stats.Agility + stats.Luck;
    }

    public int GetDefenseForSneakyAttack(IAliveEntity.PlayerStatsT stats)
    {
        return stats.Agility;
    }

    public int GetDefenseForMagicAttack(IAliveEntity.PlayerStatsT stats)
    {
        return stats.Luck;
    }
    
    public int GetDefense(IWeaponVisitor visitor, IAliveEntity.PlayerStatsT stats) => visitor.CalculateDefense(this, stats); 

    public int GetSoundValueAfterAction(IAliveEntity.PlayerStatsT playerStats) => (int)ESoundValue.LightWeapon;
}