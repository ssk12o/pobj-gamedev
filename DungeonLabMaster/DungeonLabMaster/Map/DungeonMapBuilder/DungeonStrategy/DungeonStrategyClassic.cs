using DungeonLabMaster.MovableEntities.Enemy;

namespace DungeonLabMaster.Map;

public class DungeonStrategyClassic: IDungeonStrategy
{
    public void Construct(IDungeonMapBuilder mapBuilder, IDungeonItemFactory itemFactory, IEnemyFactory enemyFactory)
    {
        mapBuilder.BuildBaseMapFull();
        mapBuilder.AddRooms(6);
        mapBuilder.AddCentralHall(12, 12);
        mapBuilder.AddCorridors(12);
        mapBuilder.AddWeapon(5,  itemFactory);
        mapBuilder.AddItems(12, itemFactory);
        mapBuilder.AddEnemies(5, enemyFactory);
        mapBuilder.SetHelpInfo(GetHelpMessages());
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