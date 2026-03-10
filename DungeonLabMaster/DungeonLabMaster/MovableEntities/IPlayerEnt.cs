namespace DungeonLabMaster.MovableEntities;

public interface IPlayerEnt
{
    string Name { get; }
    char MapChar { get; }
    int Health { get; set; }
    int MaxHealth { get; set; }
    int PosX { get; set; }
    int PosY { get; set; }
    bool Move(int y, int x);
}