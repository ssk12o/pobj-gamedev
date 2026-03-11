namespace DungeonLabMaster.Items;

public interface IItem
{
    char ItemMapName { get; }
    string Name { get; }
    string Description { get; }
    public int Handness {get; }
}