using DungeonLabMaster.MovableEntities;

namespace DungeonLabMaster.Items;

public interface IItem
{
    char ItemMapName { get; }
    string Name { get; }
    string Description { get; }
    public int Handness {get; }
    public bool IsWeapon { get; }
    public int GetDamage(IPlayerEnt.PlayerStatsT playerStats);
    public IPlayerEnt.PlayerStatsT GetStatModifiers() => new IPlayerEnt.PlayerStatsT();
}