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
        int val = Random.Shared.Next(0, 100);
        if (val < 70)
        {
            return new Mage(y, x, _itemFactory.CreateNewRandomWeapon(), 2);
        }
        else
        {
            return new Librarian(y, x, _itemFactory.CreateNewRandomWeapon(), 30);
        }
    }
    
}