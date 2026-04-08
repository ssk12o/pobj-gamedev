using DungeonLabMaster.MovableEntities;

namespace DungeonLabMaster.Items.Weapons.OrdinaryItems;

public class Rock: IItem
{
    public int GetDamage(IAliveEntity.PlayerStatsT playerStats)
    {
        return 0;
    }
    public char ItemMapName { get; } = 'r';
    public string Name { get; } = "Rock";
    public string Description { get; } = "Just a rock. Not even shiny.";

    public int Handness { get; } = 1;
    public bool IsWeapon { get; } =  false;

}