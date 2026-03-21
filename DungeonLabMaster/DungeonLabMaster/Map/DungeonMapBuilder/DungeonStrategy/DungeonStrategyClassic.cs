namespace DungeonLabMaster.Map;

public class DungeonStrategyClassic: IDungeonStrategy
{
    public  void Construct(IDungeonMapBuilder mapBuilder)
    {
        mapBuilder.BuildBaseMapFull();
        mapBuilder.AddCorridors(20);
        mapBuilder.AddRooms(5);
        mapBuilder.AddCentralHall(12, 12);
        mapBuilder.AddWeapon(5, new DungeonItemFactory());
        mapBuilder.AddItems(12, new DungeonItemFactory());
        mapBuilder.setHelpInfo(GetHelpMessages());
    }

    public   List<string> GetHelpMessages()
    {
        return new List<string>
        {
            "\t - WSAD to move",
            "\t - E to equip item (if possible) or print long items in inventory\n",
            "\t - I to remove item from inventory\n" ,
            "\t - Backspace to exit game\n",
            "\t - H to enter help menu\n"
        };
    }

    public string GetDescription()
    {
        return "Classical game arena";
    }
    
}