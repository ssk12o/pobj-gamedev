using DungeonLabMaster.Items;
using DungeonLabMaster.Items.Weapons;
using DungeonLabMaster.Map;
using DungeonLabMaster.MovableEntities.Enemy;

namespace DungeonLabMaster.DungeonThemes;

public class FactoryTheme: IDungeonTheme
{
    public string ThemeName => "Abandoned factory theme";

    public string ThemeIntroductionMessage =>"Zgrzyt metalu odbija się echem od ścian\": liczne pokoje, znajduje się tu wiele metalowych odłamków, \"Blaster\" oraz zbuntowane roboty sprzątające";
    public IDungeonStrategy GenerationStrategy => new DungeonStrategyMapArena();
    public IDungeonItemFactory ItemFactory => new FactoryItemFactory();
    public IEnemyFactory EnemyFactory => new FactoryEnemyFactory(ItemFactory);
    
    public IItem CreateArtifact()
    {
        IItem artifact = new Blaster(damage: 30);
        return new DecoratorStrong(ItemFactory.CreateNewRandomDecorator(artifact));
    }
}