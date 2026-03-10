namespace DungeonLabMaster.Items.Weapons.OrdinaryItems;

public class BigRock : IItem
{
    public char ItemMapName { get; } = 'R';
    public string Name { get; } = "Big rock";
    public void AddToInventoryFomGround(IItem item)
    {
        throw new NotImplementedException();
    }

    public IItem RemoveFromInventory()
    {
        throw new NotImplementedException();
    }

    public int Handness { get; } = 2;
}