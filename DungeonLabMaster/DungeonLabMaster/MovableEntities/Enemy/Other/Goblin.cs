using DungeonLabMaster.Items;
using DungeonLabMaster.Items.Weapons;

namespace DungeonLabMaster.MovableEntities.Enemy;

public class Goblin: Enemy, IAliveEntity
{
    public Goblin(int y, int x, IItem weapn, int hp = 10): base( y, x, weapn, "Goblin" ,hp)
    {
        ;
    }
}