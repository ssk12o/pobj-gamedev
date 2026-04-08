namespace DungeonLabMaster.Items.Weapons;

public interface IWeapon
{
    int Damage { get; }
    int Defense { get; }
    int Handness { get; }
    string Name { get; }
    string Description { get; }
}