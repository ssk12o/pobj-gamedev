using DungeonLabMaster.MovableEntities;

namespace DungeonLabMaster.Items.Weapons;

public interface IWeapon
{
    int Accept(IWeaponVisitor visitor);
    int GetDefense(IWeaponVisitor visitor, IAliveEntity.PlayerStatsT stats);
    string GetCategoryOfWeapon(); 
    // heavy, light magic
}