namespace DungeonLabMaster.Items.Weapons;

public interface IWeapon
{
    void Attack();
    int Damage { get; }
    int Defense { get; }
    int Handness { get; }
    string Name { get; }
    string Description { get; }
}