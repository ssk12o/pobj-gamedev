using DungeonLabMaster.Items.Weapons;
using DungeonLabMaster.MovableEntities;

namespace DungeonLabMaster.Items;

public class TwoHandedSword : HeavyWeapon
{ public TwoHandedSword(int damage = 50, int defense = 2, string name = "Two Handed Sword", string description = "Heavy, slow, but oh god, thats a sword.")
    {
        ItemMapName = 'S';
        Damage = damage;
        Defense = defense;
        Name = name;
        Description = description;
    }
    
}