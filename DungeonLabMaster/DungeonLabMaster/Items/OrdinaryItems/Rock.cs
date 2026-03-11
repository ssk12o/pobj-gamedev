namespace DungeonLabMaster.Items.Weapons.OrdinaryItems;

public class Rock: IItem
{
    public char ItemMapName { get; } = 'r';
    public string Name { get; } = "Rock";
    public string Description { get; } = "Just a rock. Not even shiny.";

    public int Handness { get; } = 1;
}