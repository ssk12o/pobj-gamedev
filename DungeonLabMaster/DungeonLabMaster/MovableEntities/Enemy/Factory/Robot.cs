using DungeonLabMaster.Items;
using DungeonLabMaster.Items.Weapons;

namespace DungeonLabMaster.MovableEntities.Enemy;

public class Robot: Enemy, IAliveEntity
{ 
    public Robot(int y, int x, IItem weapn, int hp = 10): base( y, x, weapn, "Robot", hp)
    {
        ;
    }
}