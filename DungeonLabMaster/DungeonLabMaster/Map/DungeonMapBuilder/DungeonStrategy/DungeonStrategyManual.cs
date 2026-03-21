using System.ComponentModel;

namespace DungeonLabMaster.Map;

public class DungeonStrategyManual: IDungeonStrategy
{
    public List<string> GetHelpMessages()
    {
        throw new NotImplementedException();
    }

    public void Construct(IDungeonMapBuilder mapBuilder)
    {
        DungeonItemFactory factory = new DungeonItemFactory();
        int ChosenOption = 1;
        while (ChosenOption > 0)
        {
            while(!int.TryParse(Console.ReadLine(), out ChosenOption)|| ChosenOption < -1 || ChosenOption > 8)
            {
                Console.WriteLine("Invalid option. try again.");
                Thread.Sleep(1000);
            }

            switch (ChosenOption)
            {
                case 0: ; break;
                case 1: mapBuilder.BuildBaseMapEmpty();break;
                case 2: mapBuilder.BuildBaseMapFull(); break;
                case 3:
                    Console.WriteLine("how many corridors add?");
                    int numberOfCorridors;
                    while(!int.TryParse(Console.ReadLine(), out numberOfCorridors) || (numberOfCorridors < 0))
                    {
                        Console.WriteLine("Invalid option. try again.");
                        Thread.Sleep(1000);
                    }
                    mapBuilder.AddCorridors(numberOfCorridors);
                    break;
                case 4: 
                    Console.WriteLine("how many corridors add?");
                    int numberOfRooms;
                    while(!int.TryParse(Console.ReadLine(), out numberOfRooms) || (numberOfRooms < 0))
                    {
                        Console.WriteLine("Invalid option. try again.");
                        Thread.Sleep(1000);
                    }
                    mapBuilder.AddCorridors(numberOfRooms);
                    break;
                case 5: mapBuilder.AddCentralHall(12, 12); break;
                case 6: 
                    Console.WriteLine("How many items add?");
                    int numOfItems;
                    while(!int.TryParse(Console.ReadLine(), out numOfItems) || (numOfItems < 0))
                    {
                        Console.WriteLine("Invalid option. try again.");
                        Thread.Sleep(1000);
                    }
                    mapBuilder.AddItems(numOfItems, factory);
                    break;
                case 7: 
                    Console.WriteLine("How many wapons add?");
                    int numOfWeapons;
                    while(!int.TryParse(Console.ReadLine(), out numOfWeapons) || (numOfWeapons < 0))
                    {
                        Console.WriteLine("Invalid option. try again.");
                        Thread.Sleep(1000);
                    }
                    mapBuilder.AddWeapon(numOfWeapons, factory);
                    break;
                
            }
        }
    }

    void PrintOptions()
    {
        Console.Clear();
        Console.WriteLine("twoaj");
    }

    public string GetDescription()
    {
        return "Build manually";
    }
}