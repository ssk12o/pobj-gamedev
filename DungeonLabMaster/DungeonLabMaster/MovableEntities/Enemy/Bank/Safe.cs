using DungeonLabMaster.Items;
using DungeonLabMaster.Items.Weapons;

namespace DungeonLabMaster.MovableEntities.Enemy;

public class Safe: Enemy
{
    public Safe(int y, int x, IItem weapn, int hp = 10): base( y, x, weapn,"Safe", hp)
    {
        ;
    }
}