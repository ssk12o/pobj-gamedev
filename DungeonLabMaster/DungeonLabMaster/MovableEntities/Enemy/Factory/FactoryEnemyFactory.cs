namespace DungeonLabMaster.MovableEntities.Enemy;

public class FactoryEnemyFactory: IEnemyFactory
{
    private IDungeonItemFactory _itemFactory;

    public FactoryEnemyFactory(IDungeonItemFactory itemFactory)
    {
        _itemFactory = itemFactory;
    }
    public IAliveEntity CreateEnemy(int y, int x)
    {
        return new Robot(y, x, _itemFactory.CreateNewRandomWeapon(), 2);
    }
    
}