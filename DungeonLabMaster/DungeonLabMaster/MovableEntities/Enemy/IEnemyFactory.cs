namespace DungeonLabMaster.MovableEntities.Enemy;

public interface IEnemyFactory
{
    IAliveEntity CreateEnemy(int y, int x);
}