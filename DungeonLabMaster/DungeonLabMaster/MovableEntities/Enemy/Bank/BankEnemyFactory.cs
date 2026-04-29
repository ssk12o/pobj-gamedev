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
        int val = Random.Shared.Next(0, 100);
        if (val < 70)
        {
            return new Safe(y, x, _itemFactory.CreateNewRandomWeapon(), 2);
        }
        else
        {
            return new Banker(y, x, _itemFactory.CreateNewRandomWeapon(), 30);
        }
    }
}