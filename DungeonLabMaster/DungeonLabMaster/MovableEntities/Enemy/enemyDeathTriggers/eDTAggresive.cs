namespace DungeonLabMaster.MovableEntities.Enemy.enemyDeathTriggers;

public class eDTAggresive: IenemyDeathTrigger
{
    public IAliveEntity.PlayerStatsT getStatsChagne()
    {
        return new IAliveEntity.PlayerStatsT()
        {
            Aggresion = 5,
            Intelligence = -5,
        };
    }
    
    public string GetTriggerText()
    {
        return "Aggresive";
    }
}