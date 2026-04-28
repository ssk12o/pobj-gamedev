using DungeonLabMaster.Items;
using DungeonLabMaster.Items.Weapons;
using DungeonLabMaster.SoundPropagation;

namespace DungeonLabMaster.MovableEntities.Enemy;

public class Mage: Enemy, IAliveEntity
{
    public Mage(int y, int x, IItem weapn, int hp = 10): base(y, x, weapn, "Mage", hp)
    {
        ;
    }

    public override void OnNotify(INotification notification)
    {
        if (notification is SoundNotification sondNotification)
        {
            base.OnNotify(notification);
        }
        else
        {
            Console.WriteLine("dupa");
            throw new Exception("dupa");
        }
    }
}