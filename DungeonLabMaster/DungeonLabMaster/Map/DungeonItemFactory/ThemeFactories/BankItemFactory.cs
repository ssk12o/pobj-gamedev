using DungeonLabMaster.Items;
using DungeonLabMaster.Items.Weapons;
using DungeonLabMaster.Map.FactoryDep;

public class BankItemFactory: IDungeonItemFactory
{
    // TODO: cleanup this unnecesary and temporary shit
    private OneHandedSwordFactory _facOneHandedSword = new OneHandedSwordFactory();
    private TwoHandedSwordFactory _facTwoHandedSword = new TwoHandedSwordFactory();
    private MoneyBagFactory _facMoneyBag = new MoneyBagFactory();
    private CurrencyFactory _facCurrency = new CurrencyFactory();
    public IItem CreateNewRandomWeapon()
    {
        IItem created; 
        int roll = Random.Shared.Next(0, 100);
        if(roll < 40)
            created = CreateNewRandomDecorator(_facOneHandedSword.Create());
        else
            created = CreateNewRandomDecorator(_facMoneyBag.Create());
        
        roll = Random.Shared.Next(0, 100);
        if(roll < 60)
            created = CreateNewRandomDecorator(created);
        
        return created;
    }

    public BankItemFactory()
    {
        ;
    }
    public IItem CreateNewRandomItem()
    {
        IItem created;
        switch (Random.Shared.Next(0, 3))
        {
            default:
                created = _facCurrency.Create();
                break;
        }
        return created;
    }

    public IItem CreateNewRandomDecorator(IItem wrapped)
    {
        int roll = Random.Shared.Next(0, 100);
        if(roll < 40)
            return wrapped;
        if (roll < 50)
            return new DecoratorWise(wrapped);
        if (roll < 60)
            return new DecoratorAgile(wrapped);
        if (roll < 70)
            return new DecoratorMad(wrapped);
        if (roll < 80)
            return new DecoratorStrong(wrapped);
        if (roll < 90)
            return new DecoratorUnlucky(wrapped);
        
        return wrapped;
    }
}