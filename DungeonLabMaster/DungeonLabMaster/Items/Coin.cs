namespace DungeonLabMaster.Items;

public class Coin: IItem
{
    public char ItemMapName { get; }
    public string Name { get; }
    public int Value { get; }
    
    public Coin(int value = 1)
    {
        Value = value;
        ItemMapName = 'C';
        Name = "Coin";
    }

    public int Handness { get; } = 1;

    public void AddToInventoryFomGround(IItem item)
    {
        throw new NotImplementedException();
    }

    public IItem RemoveFromInventory()
    {
        throw new NotImplementedException();
    }
}