namespace DungeonLabMaster.MovableEntities;

public class Player: IPlayerEnt
{
    public string Name { get; }
    public char MapChar { get; }
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public int PosX { get; set; }
    public int PosY { get; set; }
    

    public Player(int health = 100, int posX = 0, int posY = 0, string name = "Player", char mapChar = 'P')
    {
        Health = health;
        PosX = posX;
        PosY = posY;
        Name = name;
        MapChar = mapChar;
    }
    
    public bool Move(int y, int x)
    {
        PosX += x;
        PosY += y;
        return true;
    }
}