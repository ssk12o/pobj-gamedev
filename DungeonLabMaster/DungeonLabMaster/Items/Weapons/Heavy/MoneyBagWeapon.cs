namespace DungeonLabMaster.Items.Weapons.Heavy;

using DungeonLabMaster.Items.Weapons;


public class MoneyBagWeapon: HeavyWeapon
{
    public MoneyBagWeapon(int damage = 50, int defense = 2, string name = "Money bag",
        string description = "Weaponley looking bag of coins")
    {
        ItemMapName = 'B';
        Damage = damage;
        Defense = defense;
        Name = name;
        Description = description;
    }
}
