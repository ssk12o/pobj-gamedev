using DungeonLabMaster.Items.Weapons;

namespace DungeonLabMaster.Items;

public class TwoHandedSword : IWeapon, IItem
{
    public void Attack()
    {
        throw new NotImplementedException();
    }
    public int Damage { get; }
    public int Defense { get; }
    public int Handness { get; } = 2;
    public string Name { get; }
    public string Description { get; }
    public char ItemMapName { get; } = 'S';
    public bool IsWeapon { get; } =  true;


    public TwoHandedSword(int damage = 50, int defense = 2, string name = "Two Handed Sword", string description = "Heavy, slow, but oh god, thats a sword.")
    {
        Damage = damage;
        Defense = defense;
        Name = name;
        Description = description;
    }
    
}