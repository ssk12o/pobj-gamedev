using DungeonLabMaster.MovableEntities;

namespace DungeonLabMaster.Items.Weapons;

public class MagicalAttackVisitor: IWeaponVisitor
{
    public int Visit(HeavyWeapon weapon)
    {
        return 1;
    }

    public int Visit(LightWeapon weapon)
    {
        return 1;
    }

    public int Visit(MagicalWeapon weapon)
    {
        return weapon.GetDamage(new IAliveEntity.PlayerStatsT());
    }

    public int Visit(IItem item)
    {
        return 0;
    }
    
    public int CalculateDefense(HeavyWeapon weapon, IAliveEntity.PlayerStatsT  stats)
        => stats.Luck;
    
    public int CalculateDefense(LightWeapon weapon, IAliveEntity.PlayerStatsT  stats)
        => stats.Luck;
    
    public int CalculateDefense(MagicalWeapon weapon, IAliveEntity.PlayerStatsT  stats)
        => stats.Intelligence * 2;
    
    public int CalculateDefense(IItem item, IAliveEntity.PlayerStatsT stats)
        => stats.Luck;
}