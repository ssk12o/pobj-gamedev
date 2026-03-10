namespace DungeonLabMaster.Items.Weapons;


public class OneHandedSword : IWeapon
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

    public OneHandedSword(int damage = 20, int defense = 5, string name = "One handed Sword", string description = "")
    {
        Damage = damage;
        Defense = defense;
        Name = name;
        Description = description;
    }
}