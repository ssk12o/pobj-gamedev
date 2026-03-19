using DungeonLabMaster.Items;
using DungeonLabMaster.Items.Weapons.OrdinaryItems;

namespace DungeonLabMaster.Map.FactoryDep;

public class BigRockFactory: IFactoryDep
{
    public IItem Create()
    {
        return new BigRock();
    }
}