namespace DungeonLabMaster.Items;

public class Coin: IItem
{
    public char ItemMapName { get; }
    public int Value { get; }
    
    public Coin(int value = 1)
    {
        Value = value;
        ItemMapName = 'C';
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