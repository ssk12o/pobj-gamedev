using DungeonLabMaster.MovableEntities;

namespace DungeonLabMaster.Items.Weapons;

public interface IDefenseStrategy
{
    int CalculateDefense(IItem weapon, IAliveEntity.PlayerStatsT stats);
}