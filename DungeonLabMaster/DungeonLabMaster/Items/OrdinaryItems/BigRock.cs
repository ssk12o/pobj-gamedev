using DungeonLabMaster.MovableEntities;

namespace DungeonLabMaster.Items.Weapons.OrdinaryItems;

public class BigRock : IItem
{
    public int GetDamage(IPlayerEnt.PlayerStatsT playerStats)
    {
        return 0;
    }
    public char ItemMapName { get; } = 'R';
    public string Name { get; } = "Big rock";
    public string Description { get; } = "Just a rock. But this time its biiiig.";
    public int Handness { get; } = 2;
    public bool IsWeapon { get; } =  false;

}