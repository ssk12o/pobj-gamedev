using DungeonLabMaster.MovableEntities;

namespace DungeonLabMaster.Items.Weapons;


public class MagicalStaff : MagicalWeapon
{
    public MagicalStaff(int damage = 4, int defense = 18, string name = "Buckler", string description = "Small, light yet very fast shield. Still wouldnt want to get hit by it.")
    {
        ItemMapName = 'I';
        Damage = damage;
        Defense = defense;
        Name = name;
        Description = description;
    }
}