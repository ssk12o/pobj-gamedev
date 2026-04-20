using DungeonLabMaster.MovableEntities;

namespace DungeonLabMaster.Items.Weapons.OrdinaryItems;

public class Book: IItem
{
    public int GetDamage(IAliveEntity.PlayerStatsT playerStats)
    {
        return 0;
    }
    public char ItemMapName { get; } = 'b';
    public string Name { get; } = "Book";
    public string Description { get; } = "Forgotten dusted book.";

    public int Handness { get; } = 1;
    public bool IsWeapon { get; } =  false;

}