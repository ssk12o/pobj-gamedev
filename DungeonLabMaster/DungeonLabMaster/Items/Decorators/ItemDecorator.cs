using DungeonLabMaster.Items.Weapons;
using DungeonLabMaster.MovableEntities;

namespace DungeonLabMaster.Items;

public abstract class ItemDecorator: IItem, IWeapon
{
    protected virtual int GetDefenseBonus() => 0;
    protected abstract string getModifierName();
    protected abstract IAliveEntity.PlayerStatsT getModifierStats();
    protected readonly IItem wrappedItem;
    public ItemDecorator(IItem wrappedItem)
    {
        this.wrappedItem = wrappedItem;
    }


    public char ItemMapName  => wrappedItem.ItemMapName;
    public string Name => $"{getModifierName()} {wrappedItem.Name}";
    public virtual string Description => wrappedItem.Description;
    public int Handness => wrappedItem.Handness;
    public bool IsWeapon => wrappedItem.IsWeapon;
    public virtual int GetDamage(IAliveEntity.PlayerStatsT playerStats) 
        => wrappedItem.GetDamage(playerStats);

    public virtual IAliveEntity.PlayerStatsT GetStatModifiers()
    {
        return wrappedItem.GetStatModifiers() + getModifierStats();
    }

    public  int Accept(IWeaponVisitor visitor)
    {
        if (wrappedItem is IWeapon weapon)
        {
            return weapon.Accept(visitor);
        }

        return 0;
    }

    public string GetCategoryOfWeapon()
    {
        return (wrappedItem as IWeapon)?.GetCategoryOfWeapon() ?? "Unknown";
    }

    public int GetDefense(IWeaponVisitor visitor, IAliveEntity.PlayerStatsT stats)
    {
        if (wrappedItem is IWeapon weapon)
        {
            return weapon.GetDefense(visitor, stats);
        }

        return 0;
    }
}