using DungeonLabMaster.Map;

namespace DungeonLabMaster.MovableEntities.Enemy;

public class GoblinFactory: IEnemyFactory
{
    private DungeonItemFactory _itemFactory = new DungeonItemFactory();

    
    public IAliveEntity CreateEnemy(int y, int x)
    {
        return new Goblin(y, x, _itemFactory.CreateNewRandomWeapon());
    }
}