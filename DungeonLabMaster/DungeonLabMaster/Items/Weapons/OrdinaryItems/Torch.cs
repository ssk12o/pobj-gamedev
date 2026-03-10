namespace DungeonLabMaster.Items.Weapons.OrdinaryItems;

public class Torch: IItem
{
    public bool burning { get; private set; }
    public int amountOfOil { get; private set; }

    public Torch(int amountOfOil)
    {
        this.amountOfOil = amountOfOil;
        burning = false;
    }

    async void burn()
    {
        burning = true;
        while (amountOfOil > 0)
        {
            await Task.Delay(10000);
            amountOfOil--;
        }
        burning = false;
    }

    public char ItemMapName { get; private set; } = 't';
    public string Name { get; } = "Torch";
    
    
    public void AddToInventoryFomGround(IItem item)
    {
        throw new NotImplementedException();
    }

    public IItem RemoveFromInventory()
    {
        throw new NotImplementedException();
    }

    public int Handness { get; } = 1;
}