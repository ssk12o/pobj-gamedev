namespace DungeonLabMaster.Items;

public class Gold: IItem
{
    public char ItemMapName { get; }
    public int Value { get; }
    
    public Gold(int value = 1)
    {
        Value = value;
        ItemMapName = 'G';
    }
    
    public void AddToInventoryFomGround(IItem item)
    {
        throw new NotImplementedException();
    }

    public IItem RemoveFromInventory()
    {
        throw new NotImplementedException();
    }
}