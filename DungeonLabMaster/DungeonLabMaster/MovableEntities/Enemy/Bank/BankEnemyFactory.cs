namespace DungeonLabMaster.MovableEntities.Enemy;

public class BankEnemyFactory: IEnemyFactory
{
    private IDungeonItemFactory _itemFactory;

    public BankEnemyFactory(IDungeonItemFactory itemFactory)
    {
        _itemFactory = itemFactory;
    }
    public IAliveEntity CreateEnemy(int y, int x)
    {
        return new Safe(y, x, _itemFactory.CreateNewRandomWeapon(), 2);
    }
    
}