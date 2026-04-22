using DungeonLabMaster.Items;
using DungeonLabMaster.Items.Weapons;
using DungeonLabMaster.Items.Weapons.Heavy;
using DungeonLabMaster.Map;
using DungeonLabMaster.MovableEntities.Enemy;

namespace DungeonLabMaster.DungeonThemes;

public class BankTheme: IDungeonTheme
{
    public string ThemeName => "Rich bank theme";

    public string ThemeIntroductionMessage =>"Czujesz swędzenie w portfelu\": duży centralny pokój (skarbiec) z wieloma korytarzami, w lochu można znaleźć tylko monety, złoto, \"Szczęśliwą Sakwę Monet\" (broń dwuręczną) oraz ożywione i agresywne teczki i sejfy.";
    public IDungeonStrategy GenerationStrategy => new DungeonStrategyMapArena();
    public IDungeonItemFactory ItemFactory => new BankItemFactory();
    public IEnemyFactory EnemyFactory => new BankEnemyFactory(ItemFactory);
    
    public IItem CreateArtifact()
    {
        IItem artifact = new MoneyBagWeapon(damage: 30, name: "Legendary Money Bag");
        return new DecoratorStrong(  ItemFactory.CreateNewRandomDecorator(artifact));
    }
}