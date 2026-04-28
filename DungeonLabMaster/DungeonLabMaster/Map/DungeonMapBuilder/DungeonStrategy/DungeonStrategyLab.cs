using DungeonLabMaster.MovableEntities.Enemy;

namespace DungeonLabMaster.Map;

public class DungeonStrategyLab: IDungeonStrategy
{
    public void Construct(IDungeonMapBuilder mapBuilder, IDungeonItemFactory itemFactory, IEnemyFactory enemyFactory)
    {
        mapBuilder.BuildBaseMapFull();
        mapBuilder.AddRooms(5);
        mapBuilder.AddCorridors(12);
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
        return "Labirynth";
    }
}