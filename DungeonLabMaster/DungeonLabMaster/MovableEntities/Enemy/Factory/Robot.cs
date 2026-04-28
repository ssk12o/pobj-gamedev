using DungeonLabMaster.Items;
using DungeonLabMaster.Items.Weapons;

namespace DungeonLabMaster.MovableEntities.Enemy;

public class Robot: Enemy, IAliveEntity
{
    public int attack { get; set; } = 10;
    public int Armor {get; }

    public string Name { get; } = "Robot";
    public char MapChar { get; } = 'R';
    public int PosX { get; set; }
    public int PosY { get; set; }
    public IItem weapon { get; set; }
  

    public IAliveEntity.PlayerStatsT Playerstats { get; protected set; }


    public Robot(int y, int x, IItem weapn, int hp = 10): base( y, x, weapn, "Goblin", hp)
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