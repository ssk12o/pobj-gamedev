using DungeonLabMaster.Items;
using DungeonLabMaster.Map.FactoryDep;

namespace DungeonLabMaster.Map;

public class DungeonItemFactory
{
    private OneHandedSwordFactory _facOneHandedSword = new OneHandedSwordFactory();
    private TwoHandedSwordFactory _facTwoHandedSword = new TwoHandedSwordFactory();
    private BucklerFactory _facBuckler = new BucklerFactory();
    private RockFactory _facRock = new RockFactory();
    private BigRockFactory _facBigRock = new BigRockFactory();
    private CurrencyFactory _facCurrency = new CurrencyFactory();
    public IItem CreateNewRandomItemOrdinary()
    {
        IItem created;
        switch (Random.Shared.Next(0, 3))
        {
            case 0:
            case 1:
                created = CreateNewRandomItemOrdinary();
                break;
            default:
                created = CreateNewRandomWeapon();
                break;
        }
        return created;
    }

    public IItem CreateNewRandomWeapon()
    {
        IItem created;
        switch (Random.Shared.Next(0, 3))
        {
            case 0:
                created =  _facOneHandedSword.Create();
                break;
            case 1:
                created = _facTwoHandedSword.Create();
            break;
            default:
                created =  _facBuckler.Create();
            break;
        }
        if(Random.Shared.Next(2) == 0)
            created = new DecoratorStrong(created);
        if(Random.Shared.Next(4) == 0)
            created = new DecoratorUnlucky(created);
        
        return created;
    }
    
    public IItem CreateNewRandomItem()
    {
        IItem created;
        switch (Random.Shared.Next(0, 3))
        {
            case 0:
                created =     _facRock.Create();
                break;
            case 1:
                created = _facBigRock.Create(); 
                break;
            default:
                created = _facCurrency.Create();
                    break;
        }
        return created;
    }
}