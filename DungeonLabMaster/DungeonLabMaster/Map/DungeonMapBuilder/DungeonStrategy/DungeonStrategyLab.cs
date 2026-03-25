namespace DungeonLabMaster.Map;

public class DungeonStrategyLab: IDungeonStrategy
{
    public void Construct(IDungeonMapBuilder mapBuilder)
    {
        mapBuilder.BuildBaseMapFull();
        mapBuilder.AddCorridors(12);
        mapBuilder.AddRooms(5);
        mapBuilder.SetHelpInfo(GetHelpMessages());
    }

    public List<string> GetHelpMessages()
    {
        return new List<string>
        {
            "\t - WSAD to move",
            "\t - Backspace to exit game\n",
            "\t - H to enter help menu\n"
        };
    }

    public string GetDescription()
    {
        return "Lab";
    }
}

// "\t - WSAD to move",
// "\t - E to equip item (if possible) or print long items in inventory\n",
// "\t - I to remove item from inventory\n" ,
// "\t - Backspace to exit game\n",
// "\t - H to enter help menu\n"