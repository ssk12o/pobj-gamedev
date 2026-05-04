namespace DungeonLabMaster.MovableEntities.Enemy.enemyDeathTriggers;

public class eDTCowardly: IenemyDeathTrigger
{
    public IAliveEntity.PlayerStatsT getStatsChagne()
    {
        return new IAliveEntity.PlayerStatsT()
        {
            Luck = -5,
            Strength = -5,
            Aggresion = -5,
        };
    }
    
    
    public string GetTriggerText()
    {
        return "Coward";
    }
}