using DungeonLabMaster.MovableEntities;

namespace DungeonLabMaster.Items.Weapons.OrdinaryItems;

public class ScrapMetal: IItem
{
    public int GetDamage(IAliveEntity.PlayerStatsT playerStats)
    {
        return 0;
    }
    public char ItemMapName { get; } = 's';
    public string Name { get; } = "Scrap Metal";
    public string Description { get; } = "Just a stack of scrap metal. Worth almost nothing.";

    public int Handness { get; } = 2;
    public bool IsWeapon { get; } =  false;

}