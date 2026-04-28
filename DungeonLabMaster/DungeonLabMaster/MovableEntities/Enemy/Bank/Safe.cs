using DungeonLabMaster.Items;
using DungeonLabMaster.Items.Weapons;

namespace DungeonLabMaster.MovableEntities.Enemy;

public class Safe: Enemy
{
    public int Armor {get; }
    public int attack { get; set; } = 10;

    public string Name { get; } = "Goblin";
    public char MapChar { get; } = 'g';
    public int PosX { get; set; }
    public int PosY { get; set; }
    public IItem weapon { get; set; }
    public IAliveEntity.PlayerStatsT Playerstats { get; protected set; }

    public Safe(int y, int x, IItem weapn, int hp = 10): base( y, x, weapn,"Safe", hp)
    {
        ;
    }

    public int CalculateAttackDamage(IWeaponVisitor vis)
    {
        int h = 0;
        
        var _weapon = weapon as IWeapon;
        if (_weapon != null && weapon.IsWeapon)
        {
            h = _weapon.Accept(vis);
        }
        
        return Math.Max(0, h);
    }


}