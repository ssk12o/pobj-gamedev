using DungeonLabMaster.Items;

namespace DungeonLabMaster.Map.FactoryDep;

public class CurrencyFactory: IFactoryDep
{
    int maxValue = 10;
    public IItem Create()
    {
        int r = Random.Shared.Next(0, 2);
        int amount = Random.Shared.Next(0, maxValue+1);
        switch (r)
        {
            case 0:
                return new Coin(amount);
            break;
            default:
                return new Gold(amount);
            break;
        }
    }
}