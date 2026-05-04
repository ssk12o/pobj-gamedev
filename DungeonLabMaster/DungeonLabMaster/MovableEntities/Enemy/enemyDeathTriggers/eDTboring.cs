namespace DungeonLabMaster.MovableEntities.Enemy.enemyDeathTriggers;

public class eDTboring: IenemyDeathTrigger
{
    public IAliveEntity.PlayerStatsT getStatsChagne()
    {
        return new IAliveEntity.PlayerStatsT();
    }
    
    public string GetTriggerText()
    {
        return "duh";
    }
}