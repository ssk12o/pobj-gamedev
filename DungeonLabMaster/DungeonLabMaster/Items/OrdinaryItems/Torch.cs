using DungeonLabMaster.MovableEntities;

namespace DungeonLabMaster.Items.Weapons.OrdinaryItems;

public class Torch: IItem
{
    public int GetDamage(IAliveEntity.PlayerStatsT playerStats)
    {
        return 0;
    }
    public bool Burning { get; private set; }
    public int AmountOfOil { get; private set; }

    public Torch(int amountOfOil)
    {
        this.AmountOfOil = amountOfOil;
        Burning = false;
    }

    async void Burn()
    {
        Burning = true;
        while (AmountOfOil > 0)
        {
            await Task.Delay(10000);
            AmountOfOil--;
        }
        Burning = false;
    }

    public char ItemMapName { get; private set; } = 't';
    public string Name { get; } = "Torch";
    
    public  string Description { get; } = "The name explains everything.";

    public int Handness { get; } = 1;
    public bool IsWeapon { get; } =  false;

}