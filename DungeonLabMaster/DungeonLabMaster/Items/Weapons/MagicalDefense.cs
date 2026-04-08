using DungeonLabMaster.MovableEntities;

namespace DungeonLabMaster.Items.Weapons;

public class MagicalDefense: IDefenseStrategy
{
    public int CalculateDefense(IItem weapon, IAliveEntity.PlayerStatsT stats)
    {
        return weapon.GetDefenseForNormalAttack(stats);
    }
}