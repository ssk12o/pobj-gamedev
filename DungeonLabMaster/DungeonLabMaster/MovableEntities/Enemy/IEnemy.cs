using DungeonLabMaster.Items;

namespace DungeonLabMaster.MovableEntities.Enemy;

public interface IEnemy
{
    public IItem weapon { get; protected set; }
    public int attack { get; protected set; }

    public int Armor {get; }
    
}