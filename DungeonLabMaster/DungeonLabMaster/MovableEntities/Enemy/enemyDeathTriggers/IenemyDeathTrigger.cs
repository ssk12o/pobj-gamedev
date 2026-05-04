namespace DungeonLabMaster.MovableEntities.Enemy.enemyDeathTriggers;

public interface IenemyDeathTrigger
{
    public IAliveEntity.PlayerStatsT getStatsChagne();
    public string GetTriggerText();
}