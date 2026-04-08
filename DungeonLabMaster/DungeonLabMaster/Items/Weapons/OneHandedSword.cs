using DungeonLabMaster.MovableEntities;

namespace DungeonLabMaster.Items.Weapons;


public class OneHandedSword : IWeapon, IItem
{
    public int GetDamage(IPlayerEnt.PlayerStatsT playerStats)
    {
        return Damage;
    }
    public int Damage { get; }
    public int Defense { get; }
    public int Handness { get; } = 1;
    public string Name { get; }
    public string Description { get; }
    public char ItemMapName { get; } = 's';
    public bool IsWeapon { get; } =  true;


    public OneHandedSword(int damage = 20, int defense = 4, string name = "One handed Sword", string description = "The workhorse of bloodshed.")
    {
        Damage = damage;
        Defense = defense;
        Name = name;
        Description = description;
    }
    
}