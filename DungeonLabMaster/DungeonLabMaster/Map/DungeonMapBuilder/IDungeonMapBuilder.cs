namespace DungeonLabMaster.Map;

public interface IDungeonMapBuilder
{
    void BuildBaseMapEmpty();
    void BuildBaseMapFull();

    void AddCorridors();
    void AddRooms();
    void AddCentralHall();
    void AddItems();
    void AddWeapon();
}