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
    }
    int PosX { get; set; }
    int PosY { get; set; }
    bool Move(int y, int x);
}