namespace DungeonLabMaster.Items;

public interface IItem
{
    char ItemMapName { get; }
    string Name { get; }
    
    void AddToInventoryFomGround(IItem item);
    IItem RemoveFromInventory();
    public int Handness {get; }
}