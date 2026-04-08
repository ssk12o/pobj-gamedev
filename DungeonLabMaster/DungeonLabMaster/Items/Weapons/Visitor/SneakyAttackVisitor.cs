using DungeonLabMaster.MovableEntities;

namespace DungeonLabMaster.Items.Weapons;

public class SneakyAttackVisitor: IWeaponVisitor
{
    public int Visit(HeavyWeapon weapon)
    {
        return weapon.GetDamage(new IAliveEntity.PlayerStatsT()) / 2;
    }

    public int Visit(LightWeapon weapon)
    {
        return weapon.GetDamage(new IAliveEntity.PlayerStatsT()) * 2;
    }

    public int Visit(MagicalWeapon weapon)
    {
        return 1;
    }

    public int Visit(IItem item)
    {
        return 0;
    }
    
    public int CalculateDefense(HeavyWeapon weapon, IAliveEntity.PlayerStatsT stats)
        => stats.Strength;
    
    public int CalculateDefense(LightWeapon weapon, IAliveEntity.PlayerStatsT stats)
        => stats.Agility;
    
    public int CalculateDefense(MagicalWeapon weapon, IAliveEntity.PlayerStatsT stats)
        => 0; // Brak obrony w ataku skrytym
    
    public int CalculateDefense(IItem item, IAliveEntity.PlayerStatsT stats)
        => 0;
}