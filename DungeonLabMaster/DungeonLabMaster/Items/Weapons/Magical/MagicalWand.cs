using DungeonLabMaster.MovableEntities;

namespace DungeonLabMaster.Items.Weapons;


public class MagicalWand : MagicalWeapon
{
    public MagicalWand(int damage = 4, int defense = 18, string name = "Magical Wand", string description = "Magical stuff -- brrrrrrrrrrr")
    {
        ItemMapName = 'I';
        Damage = damage;
        Defense = defense;
        Name = name;
        Description = description;
    }
}