namespace DungeonLabMaster.MovableEntities.Enemy.enemyDeathTriggers;

public class eDTVigilantv: IenemyDeathTrigger
{
    public IAliveEntity.PlayerStatsT getStatsChagne()
    {
        return new IAliveEntity.PlayerStatsT()
        {
            Luck = +5,
            Agility = 5,
            Intelligence = 5,
        };
    }

    public string GetTriggerText()
    {
        return "Vigliant";
    }
}