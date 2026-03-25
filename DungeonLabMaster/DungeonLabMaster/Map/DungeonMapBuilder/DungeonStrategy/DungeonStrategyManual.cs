using System.ComponentModel;

namespace DungeonLabMaster.Map;

public class DungeonStrategyManual: IDungeonStrategy
{
    public List<string> GetHelpMessages()
    {
        return new List<string>
        {
            "\t - WSAD to move",
            "\t - E to equip item (if possible) or print long items in inventory\n",
            "\t - I to remove item from inventory\n" ,
            "\t - Backspace to exit game\n",
            "\t - H to enter help menu\n"
        };
    }

    public void Construct(IDungeonMapBuilder mapBuilder)
    {
        DungeonItemFactory factory = new DungeonItemFactory();
        int chosenOption = 1;
        while (chosenOption > 0)
        {
            PrintOptions();
            while(!int.TryParse(Console.ReadLine(), out chosenOption)|| chosenOption < -1 || chosenOption > 8)
            {
                Console.WriteLine("Invalid option. try again.");
                Thread.Sleep(1000);
            }

            switch (chosenOption)
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
                    Console.WriteLine("how many rooms add?");
                    int numberOfRooms;
                    while(!int.TryParse(Console.ReadLine(), out numberOfRooms) || (numberOfRooms < 0))
                    {
                        Console.WriteLine("Invalid option. try again.");
                        Thread.Sleep(1000);
                    }
                    mapBuilder.AddRooms(numberOfRooms);
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
        Console.WriteLine(
            "Manual builder menu! Options:\n" +
            "[0] - to exit\n" + 
            "[1] - to set map empty\n " +
            "[2] - to set map full\n" +
            "[3] - to add random corridors\n" + 
            "[4] - to add rooms\n" + 
            "[5] - to add central hall\n"+
            "[6] - to add random items\n" +
            "[7] - to add random weapons"
            );
}

    public string GetDescription()
    {
        return "Build manually";
    }
}