namespace DungeonLabMaster.MovableEntities;

public interface IPlayerEnt
{
    string Name { get; }
    char MapChar { get; }
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
}