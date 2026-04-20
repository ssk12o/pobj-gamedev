using DungeonLabMaster.Items;
using DungeonLabMaster.Items.Weapons;

namespace DungeonLabMaster.MovableEntities.Enemy;

public class Mage: IAliveEntity, IEnemy
{
    public int Armor {get; }

    public string Name { get; } = "Mage";
    public char MapChar { get; } = 'M';
    public int PosX { get; set; }
    public int PosY { get; set; }
    public IItem weapon { get; set; }
  

    public IAliveEntity.PlayerStatsT Playerstats { get; protected set; }


    public Mage(int y, int x, IItem weapn, int hp = 10)
    {
        PosY = y;
        PosX = x;
        weapon = weapn;
        Playerstats = new IAliveEntity.PlayerStatsT();
        Playerstats.Health = Playerstats.MaxHealth = hp;
        Armor = 2;
    }
    
    public bool Move(int y, int x)
    {
        throw new NotImplementedException();
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