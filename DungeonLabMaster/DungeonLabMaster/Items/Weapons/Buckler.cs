namespace DungeonLabMaster.Items.Weapons;


public class Buckler : IWeapon
{
    public void Attack()
    {
        throw new NotImplementedException();
    }
    public int Damage { get; }
    public int Defense { get; }
    public int Handness { get; } = 1;
    public string Name { get; }
    public string Description { get; }

    public Buckler(int damage = 20, int defense = 5, string name = "Buckler", string description = "")
    {
        Damage = damage;
        Defense = defense;
        Name = name;
        Description = description;
    }
}