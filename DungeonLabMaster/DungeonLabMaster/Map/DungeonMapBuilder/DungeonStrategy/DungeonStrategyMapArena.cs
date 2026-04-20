using DungeonLabMaster.MovableEntities.Enemy;

namespace DungeonLabMaster.Map;

public class DungeonStrategyMapArena:IDungeonStrategy
{
    public void Construct(IDungeonMapBuilder mapBuilder, IDungeonItemFactory itemFactory, IEnemyFactory enemyFactory)
    {
        mapBuilder.BuildBaseMapEmpty();
        mapBuilder.AddWeapon(4, itemFactory);
        mapBuilder.AddEnemies(3, enemyFactory);
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
        return "Empty arena -- just for fight!";
    }
}