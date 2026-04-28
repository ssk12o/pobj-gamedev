using DungeonLabMaster.MovableEntities;

namespace DungeonLabMaster.Items.Weapons;

public class HeavyWeapon : IWeapon, IItem
{
    public int GetDamage(IAliveEntity.PlayerStatsT playerStats)
    {
        return Damage;
    }

    public int Damage { get; protected set; }
    public int Defense { get; protected set; }
    public int Handness { get; } = 2;
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public char ItemMapName { get; protected set; }
    public bool IsWeapon { get; protected set; } = true;

    public int Accept(IWeaponVisitor visitor) => visitor.Visit(this);

    public string GetCategoryOfWeapon() => "Heavy";

    public int GetDefense(IWeaponVisitor visitor, IAliveEntity.PlayerStatsT stats) =>
        visitor.CalculateDefense(this, stats);

    public int GetSoundValueAfterAction(IAliveEntity.PlayerStatsT playerStats) => (int)ESoundValue.HeavyWeapon;
}