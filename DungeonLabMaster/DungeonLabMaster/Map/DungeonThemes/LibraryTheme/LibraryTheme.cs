using DungeonLabMaster.Items;
using DungeonLabMaster.Items.Weapons;
using DungeonLabMaster.Map;
using DungeonLabMaster.MovableEntities.Enemy;

namespace DungeonLabMaster.DungeonThemes;

public class LibraryTheme: IDungeonTheme
{
    public string ThemeName => "Ancient library";

    public string ThemeIntroductionMessage =>
        "\"Zapach starych książek wypełnia powietrze\": loch składa się z wielu korytarzy, pula przedmiotów zawiera książki z pozytywnymi modyfikatorami mądrości, w lochu jest \"Czarna Różdżka\" i magowie;";

    public IDungeonStrategy GenerationStrategy => new DungeonStrategyMapArena();
    public IDungeonItemFactory ItemFactory => new LibraryItemFactory();
    public IEnemyFactory EnemyFactory => new LibraryEnemyFactory(ItemFactory);
    
    public IItem CreateArtifact()
    {
        IItem artifact = new MagicalStaff(damage: 30);
        return new DecoratorStrong(  ItemFactory.CreateNewRandomDecorator(artifact));
    }
}