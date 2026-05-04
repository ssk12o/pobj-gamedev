using DungeonLabMaster.Items;
using DungeonLabMaster.Items.Weapons;
using DungeonLabMaster.MovableEntities.Enemy.enemyDeathTriggers;

namespace DungeonLabMaster.MovableEntities.Enemy;

public class Robot: Enemy, IAliveEntity
{ 
    public Robot(int y, int x, IItem weapn, int hp = 10): base( y, x, weapn, "Robot", hp, new eDTAggresive())
    {
        ;
    }
}