using DungeonLabMaster.MovableEntities.Enemy;

namespace DungeonLabMaster.Map;

public interface IDungeonStrategy: IDungeonHelp
{
    void Construct(IDungeonMapBuilder mapBuilder, IDungeonItemFactory itemFactory, IEnemyFactory enemyFactory);
    string GetDescription();
}