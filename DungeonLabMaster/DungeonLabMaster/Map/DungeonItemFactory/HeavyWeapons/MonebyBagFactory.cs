using DungeonLabMaster.Items;
using DungeonLabMaster.Items.Weapons;
using DungeonLabMaster.Items.Weapons.Heavy;
using DungeonLabMaster.Map.FactoryDep;

public class MoneyBagFactory: IFactoryDep
{
    private int _minAttack = 2;
    private int _maxAttack = 5;
    private int _minDefense = 20;
    private int _maxDefense = 30;

    public IItem Create()
    {
        // int index = Random.Shared.Next(BucklerNames.Length);
        return new MoneyBagWeapon(Random.Shared.Next(_minAttack, _maxAttack+1), Random.Shared.Next(_minDefense,_maxDefense));
    }
}