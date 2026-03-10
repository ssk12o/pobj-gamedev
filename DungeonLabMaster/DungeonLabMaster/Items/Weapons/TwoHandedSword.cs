using DungeonLabMaster.Items.Weapons;

namespace DungeonLabMaster.Items;

public class TwoHandedSword : IWeapon
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

    public TwoHandedSword(int damage = 50, int defense = 2, string name = "Sword", string description = "")
    {
        Damage = damage;
        Defense = defense;
        Name = name;
        Description = description;
    }
}