namespace DungeonLabMaster.Items.Weapons;


public class OneHandedSword : IWeapon, IItem
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
    public char ItemMapName { get; } = 's';

    public OneHandedSword(int damage = 20, int defense = 4, string name = "One handed Sword", string description = "The workhorse of bloodshed.")
    {
        Damage = damage;
        Defense = defense;
        Name = name;
        Description = description;
    }

    public void AddToInventoryFomGround(IItem item)
    {
        throw new NotImplementedException();
    }

    public IItem RemoveFromInventory()
    {
        throw new NotImplementedException();
    }
}