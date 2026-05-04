using DungeonLabMaster.Items;
using DungeonLabMaster.MovableEntities.Enemy.enemyDeathTriggers;

namespace DungeonLabMaster.MovableEntities.Enemy;

public class Librarian: Enemy
{
    public Librarian(int y, int x, IItem weapn, int hp = 10): base(y, x, weapn, "Librarian", hp, new eDTVigilantv())
    {
        ;
    }
}