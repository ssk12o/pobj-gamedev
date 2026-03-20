using DungeonLabMaster.Items;
using DungeonLabMaster.Items.Weapons.OrdinaryItems;

namespace DungeonLabMaster.Map.FactoryDep;

public class RockFactory: IFactoryDep
{
    public IItem Create()
    {
        return new Rock();
    }
}