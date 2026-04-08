using DungeonLabMaster.MovableEntities;

namespace DungeonLabMaster.Items;

public class Coin: IItem
{
    public int GetDamage(IPlayerEnt.PlayerStatsT playerStats)
    {
        return 0;
    }
    public char ItemMapName { get; }
    public string Name { get; }
    public int Value { get; }
    public string Description { get; }
    public bool IsWeapon { get; } =  false;
    
    public Coin(int value = 1)
    {
        Description = "Old classy gold coin!.";
        Value = value;
        ItemMapName = 'C';
        Name = "Coin";
    }

    public int Handness { get; } = 1;
    
}