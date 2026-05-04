using DungeonLabMaster.Items;
using DungeonLabMaster.Items.Weapons;
using DungeonLabMaster.MovableEntities.Enemy.enemyDeathTriggers;

namespace DungeonLabMaster.MovableEntities.Enemy;

public class Banker: Enemy
{
    public Banker(int y, int x, IItem weapn, int hp = 10): base( y, x, weapn,"Banker", hp, new eDTCowardly())
    {
        ;
    }
}