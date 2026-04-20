namespace DungeonLabMaster.MovableEntities.Enemy;

public class LibraryEnemyFactory: IEnemyFactory
{
    private IDungeonItemFactory _itemFactory;

    public LibraryEnemyFactory(IDungeonItemFactory itemFactory)
    {
        _itemFactory = itemFactory;
    }
    public IAliveEntity CreateEnemy(int y, int x)
    {
        return new Mage(y, x, _itemFactory.CreateNewRandomWeapon(), 2);
    }
    
}