using DungeonLabMaster.Items;
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
    void AddItems(int  numberOfItems, IDungeonItemFactory factory);
    void AddWeapon(int numberOfWeapons, IDungeonItemFactory factory);
    void AddEnemies(int numberOfEnemies, IEnemyFactory factory);
    void AddCustomItem(IItem item);
}