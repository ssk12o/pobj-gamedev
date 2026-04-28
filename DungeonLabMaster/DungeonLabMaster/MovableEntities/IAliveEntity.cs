using DungeonLabMaster.Items.Weapons;
using DungeonLabMaster.SoundPropagation;

namespace DungeonLabMaster.MovableEntities;

public interface IAliveEntity
{
    string Name { get; }
    char MapChar { get; }
    
    public PlayerStatsT Playerstats { get;  }
    
    public class PlayerStatsT
    {
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Intelligence { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Luck { get; set; }
        public int Aggresion { get; set; }

        
        public static PlayerStatsT operator +(PlayerStatsT a, PlayerStatsT b)
        {
            return new PlayerStatsT
            {
                Strength = a.Strength + b.Strength,
                Agility = a.Agility + b.Agility,
                Intelligence = a.Intelligence + b.Intelligence,
                Health = a.Health + b.Health,
                MaxHealth = a.MaxHealth + b.MaxHealth,
                Luck = a.Luck + b.Luck,
                Aggresion = a.Aggresion + b.Aggresion
            };
        }
    }
    int PosX { get; set; }
    int PosY { get; set; }
    bool Move(int y, int x);
    public int TakeDamage(int damage)
    {
        Playerstats.Health = Playerstats.Health -  damage;
        if (Playerstats.Health <= 0)
        {
            Console.WriteLine($"{Name} is dead");
            Playerstats.Health = 0;
        }
        Console.WriteLine($"{Name} takes {damage} damage and ends up with {Playerstats.Health} hp.");
        
        return Playerstats.Health;
    }

    public int HealDamage(int healing)
    {
        int end = Math.Max(Playerstats.MaxHealth, Playerstats.Health + healing);
        Console.WriteLine($"Player heals {end -  Playerstats.MaxHealth} HP and ends up with {end} HP");
        return Playerstats.Health = end; 
    }

    public int CalculateAttackDamage(IWeaponVisitor vis);

    public  int CalculateDefense(IWeaponVisitor vis, IWeapon enemyWeapon)
    {
        return enemyWeapon.GetDefense(vis, Playerstats);
    }
    
   
}