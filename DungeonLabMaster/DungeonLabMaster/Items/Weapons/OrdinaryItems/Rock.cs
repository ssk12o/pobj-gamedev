namespace DungeonLabMaster.Items.Weapons.OrdinaryItems;

public class Rock: IItem
{
    public char ItemMapName { get; } = 'r';
    public string Name { get; } = "Rock";
    public void AddToInventoryFomGround(IItem item)
    {
        throw new NotImplementedException();
    }

    public IItem RemoveFromInventory()
    {
        throw new NotImplementedException();
    }

    public int Handness { get; } = 1;
}