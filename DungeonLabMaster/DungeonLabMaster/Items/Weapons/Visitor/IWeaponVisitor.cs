using DungeonLabMaster.MovableEntities;

namespace DungeonLabMaster.Items.Weapons;

public interface IWeaponVisitor
{
    int Visit(HeavyWeapon weapon);
    int Visit(LightWeapon weapon);
    int Visit(MagicalWeapon weapon);
    int Visit(IItem item);
    
    int CalculateDefense(HeavyWeapon weapon, IAliveEntity.PlayerStatsT stats);
    int CalculateDefense(LightWeapon weapon, IAliveEntity.PlayerStatsT stats);
    int CalculateDefense(MagicalWeapon weapon, IAliveEntity.PlayerStatsT stats);
    int CalculateDefense(IItem item, IAliveEntity.PlayerStatsT stats);
}