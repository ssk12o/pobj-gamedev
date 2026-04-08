using DungeonLabMaster.MovableEntities.Enemy;

namespace DungeonLabMaster.Map;

public interface IDungeonMapBuilder
{
    public Map GetMap();
    void BuildBaseMapEmpty();
    void BuildBaseMapFull();
    public void SetHelpInfo(List<string> helpTextList);
    void AddCorridors(int count);
    void AddRooms(int count);
    void AddCentralHall(int height, int width);
    void AddItems(int  numberOfItems, DungeonItemFactory factory);
    void AddWeapon(int numberOfWeapons, DungeonItemFactory factory);
    void AddEnemies(int numberOfEnemies, IEnemyFactory factory);
}