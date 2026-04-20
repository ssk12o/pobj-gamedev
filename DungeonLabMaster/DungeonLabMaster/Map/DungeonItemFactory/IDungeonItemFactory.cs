using DungeonLabMaster.Items;

public interface IDungeonItemFactory
{
    public IItem CreateNewRandomWeapon();
    public IItem CreateNewRandomItem();
    public IItem CreateNewRandomDecorator(IItem wrapped);
}