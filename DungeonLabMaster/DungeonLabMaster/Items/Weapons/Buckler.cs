namespace DungeonLabMaster.Items.Weapons;


public class Buckler : IWeapon, IItem
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
    public char ItemMapName { get; } = 'o';
    public bool IsWeapon { get; } =  true;

    public Buckler(int damage = 4, int defense = 18, string name = "Buckler", string description = "Small, light yet very fast shield. Still wouldnt want to get hit by it.")
    {
        Damage = damage;
        Defense = defense;
        Name = name;
        Description = description;
    }
    
}