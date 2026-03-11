namespace DungeonLabMaster.Items.Weapons.OrdinaryItems;

public class BigRock : IItem
{
    public char ItemMapName { get; } = 'R';
    public string Name { get; } = "Big rock";
    public string Description { get; } = "Just a rock. But this time its biiiig.";
    public int Handness { get; } = 2;
}