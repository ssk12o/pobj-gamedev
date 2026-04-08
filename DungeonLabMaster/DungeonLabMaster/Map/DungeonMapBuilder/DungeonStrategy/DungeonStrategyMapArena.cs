using DungeonLabMaster.MovableEntities.Enemy;

namespace DungeonLabMaster.Map;

public class DungeonStrategyMapArena:IDungeonStrategy
{
    private IEnemyFactory _enemyFactory = new GoblinFactory();
    public void Construct(IDungeonMapBuilder mapBuilder)
    {
        mapBuilder.BuildBaseMapEmpty();
        mapBuilder.AddWeapon(4, new DungeonItemFactory());
        mapBuilder.AddEnemies(3, _enemyFactory);
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