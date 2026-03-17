namespace DungeonLabMaster.Items;

public class Gold: IItem
{
    public char ItemMapName { get; }
    public int Value { get; }
    public string Name { get; }
    public string Description { get; }
    public bool IsWeapon { get; } =  false;

    public Gold(int value = 1)
    {
        Description = "Universal symbol of wealth";
        Value = value;
        ItemMapName = 'G';
        Name = "Gold";
    }
    public int Handness { get; } = 1;

}