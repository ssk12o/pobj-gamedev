using DungeonLabMaster.MovableEntities;

namespace DungeonLabMaster.Items;

public abstract class ItemDecorator: IItem
{
    protected abstract string getModifierName();
    protected abstract IPlayerEnt.PlayerStatsT getModifierStats();
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
    public virtual int GetDamage(IPlayerEnt.PlayerStatsT playerStats) 
        => wrappedItem.GetDamage(playerStats);

    public virtual IPlayerEnt.PlayerStatsT GetStatModifiers()
    {
        return wrappedItem.GetStatModifiers() + getModifierStats();
    }
}