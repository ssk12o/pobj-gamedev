namespace DungeonLabMaster.Items;

public interface IItem
{
    char ItemMapName { get; }
    
    void AddToInventoryFomGround(IItem item);
    IItem RemoveFromInventory();
}