using DungeonLabMaster.MovableEntities;

namespace DungeonLabMaster.Items.Weapons;


public class OneHandedSword : LightWeapon
{ 
    public OneHandedSword(int damage = 20, int defense = 4, string name = "One handed Sword", string description = "The workhorse of bloodshed.")
    {
        ItemMapName = 's';
        Damage = damage;
        Defense = defense;
        Name = name;
        Description = description;
    }
    
}