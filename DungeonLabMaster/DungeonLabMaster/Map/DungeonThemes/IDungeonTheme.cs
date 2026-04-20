using DungeonLabMaster.Items;
using DungeonLabMaster.Map;
using DungeonLabMaster.MovableEntities.Enemy;

namespace DungeonLabMaster.DungeonThemes;

public interface IDungeonTheme
{
    string ThemeName { get; }
    string ThemeIntroductionMessage { get; }
    IDungeonStrategy GenerationStrategy { get; }
    IDungeonItemFactory ItemFactory { get; }
    IEnemyFactory EnemyFactory { get;  }
    IItem CreateArtifact();

    public Map.Map getMap()
    {
        IDungeonMapBuilder builder = new DungeonMapBuilder();
        GenerationStrategy.Construct(builder, ItemFactory, EnemyFactory);
        builder.AddCustomItem(CreateArtifact());
        return builder.GetMap();
    }
}