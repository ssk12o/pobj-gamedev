
using DungeonLabMaster.MovableEntities;

namespace DungeonLabMaster.Items;

public interface IItem
{
    char ItemMapName { get; }
    string Name { get; }
    string Description { get; }
    public int Handness {get; }
    public bool IsWeapon { get; }
    public int GetDamage(IAliveEntity.PlayerStatsT playerStats);
    public IAliveEntity.PlayerStatsT GetStatModifiers() => new IAliveEntity.PlayerStatsT();
    
    
    public int GetDefenseForNormalAttack(IAliveEntity.PlayerStatsT stats) => stats.Agility;
    public int GetDefenseForSneakyAttack(IAliveEntity.PlayerStatsT stats) => 0;
    public int GetDefenseForMagicalAttack(IAliveEntity.PlayerStatsT stats) => stats.Luck;

    public int GetSoundValueAfterAction(IAliveEntity.PlayerStatsT playerStats)
    {
        return (int) ESoundValue.Item;
    }
}