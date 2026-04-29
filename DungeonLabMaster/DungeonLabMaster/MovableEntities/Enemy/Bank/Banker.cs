using DungeonLabMaster.Items;
using DungeonLabMaster.Items.Weapons;

namespace DungeonLabMaster.MovableEntities.Enemy;

public class Banker: Enemy
{
    public Banker(int y, int x, IItem weapn, int hp = 10): base( y, x, weapn,"Banker", hp)
    {
        ;
    }
}