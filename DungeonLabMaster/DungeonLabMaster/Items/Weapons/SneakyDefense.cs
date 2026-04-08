using DungeonLabMaster.MovableEntities;

namespace DungeonLabMaster.Items.Weapons;

public class SneakyDefense: IDefenseStrategy
{
    public int CalculateDefense(IItem weapon, IAliveEntity.PlayerStatsT stats)
    {
        return weapon.GetDefenseForNormalAttack(stats);
    }
}