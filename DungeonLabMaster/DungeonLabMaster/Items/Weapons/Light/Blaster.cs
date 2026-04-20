namespace DungeonLabMaster.Items.Weapons;

public class Blaster: LightWeapon
{ 
    public Blaster(int damage = 20, int defense = 4, string name = "Blaster", string description = "The workhorse space of bloodshed.")
    {
        ItemMapName = 'b';
        Damage = damage;
        Defense = defense;
        Name = name;
        Description = description;
    }
    
}