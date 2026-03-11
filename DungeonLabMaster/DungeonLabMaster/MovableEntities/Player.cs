using System.Text;
using DungeonLabMaster.Items;
using DungeonLabMaster.Items.Weapons;

namespace DungeonLabMaster.MovableEntities;

public class Player: IPlayerEnt
{
    public string Name { get; }
    public char MapChar { get; }

    public int PosX { get; set; }
    public int PosY { get; set; }
    public PlayerStatsT PlayerStats = new PlayerStatsT();
    public int GoldCount { get; private set; } = 0;
    public int CoinCount { get; private set; } = 0;

    public class PlayerStatsT
    {
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Intelligence { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Luck { get; set; }
        public int Aggresion { get; set; }
    }
    
    private List<IItem> _inventory;
    public int NumberOfItemsInEquipment => _inventory.Count;
    public IItem? RightHand { get; private set; }
    public IItem? LeftHand { get; private set; }
    private HandsUsability _hands = HandsUsability.NoneUsed;

    private enum HandsUsability
    {
        NoneUsed,
        LeftUsed,
        RightUsed,
        BothUsed,
        TwoHanded
    };

    public Player(int health = 100, int posY = 0, int posX = 0, string name = "Player",
        char mapChar = 'P', List<IItem>? startingInventory = null)
    {
        PlayerStats.Health = PlayerStats.MaxHealth = health;
        PosX = posX;
        PosY = posY;
        Name = name;
        MapChar = mapChar;
        _inventory = startingInventory ?? new List<IItem>();
    }
    
    public void AddCoin(int amount){CoinCount += amount;}
    public void AddGold(int amount){GoldCount += amount;}

    public int GetCoins(int amount)
    {
        if (amount > CoinCount) return 0;
        CoinCount  -= amount;
        return amount;
    }
    public int GetGold(int amount)
    {
        if (amount > GoldCount) return 0;
        GoldCount  -= amount;
        return amount;
    }
    public void HandItem(IItem item)
    {
        if (item.Handness == 2)
        {
            IItem old;
            switch (_hands)
            {
                case HandsUsability.LeftUsed:
                    old = LeftHand;
                    AddItemToEquipment(old);
                    LeftHand = null;
                    break;
                
                case HandsUsability.RightUsed or HandsUsability.TwoHanded:
                    old = RightHand;
                    AddItemToEquipment(old);
                    break;

                case HandsUsability.BothUsed:
                    old = LeftHand;
                    AddItemToEquipment(old);
                    LeftHand = null;
                    old = RightHand;
                    AddItemToEquipment(old);
                    break;
            }

            _hands = HandsUsability.TwoHanded;
            RightHand = item;
            
        }
        else
        {
            switch (_hands)
            {
                case HandsUsability.LeftUsed:
                    RightHand = item;
                    _hands = HandsUsability.BothUsed;
                    break;
                case HandsUsability.RightUsed:
                    LeftHand = item;
                    _hands = HandsUsability.BothUsed;
                    break;
                case HandsUsability.NoneUsed:
                    RightHand = item;
                    _hands = HandsUsability.RightUsed;
                    break;
                case HandsUsability.BothUsed:
                    Console.WriteLine("Chose which hand needs to be emptied. R or L");
                    bool spin = true;
                    while (spin)
                    {
                        ConsoleKey key = Console.ReadKey(true).Key;
                        switch (key)
                        {
                            case ConsoleKey.R:
                                IItem oldH = RightHand;
                                RightHand = item;
                                AddItemToEquipment(oldH);
                                spin = false;
                                break;
                            case ConsoleKey.L:
                                IItem oldHl = LeftHand;
                                LeftHand = item;
                                AddItemToEquipment(oldHl);
                                spin = false;
                                break;
                        }
                    }
                    break;

                case HandsUsability.TwoHanded:
                    IItem old = RightHand;
                    AddItemToEquipment(old);
                    RightHand = item;
                    break;
            }
        }
    }

    public void AddItemToEquipment(IItem item)
    {
        if (item.Name == "Gold")
        {
            AddGold(1);
            return;
        } else if (item.Name == "Coin")
        {
            AddCoin(1);
            return;
        }
        _inventory.Add(item);
    }

    public IItem? RemoveItemNoFromEquipment(int number)
    {
        if(0 >= _inventory.Count || _inventory.Count <= number) return null;
        
        IItem ret = _inventory[number];
        _inventory.RemoveAt(number);
        return ret;
    }

    public StringBuilder GetInventoryListSb()
    {
        int i = 0;
        StringBuilder sb = new();
        sb.AppendLine($"Amount of Gold {GoldCount}");
        sb.AppendLine($"Amount of Coin {CoinCount}");
        foreach (IItem item in _inventory)
        {
            sb.Append((i++).ToString()).Append($"\t{item.ItemMapName} - ").Append(item.Name).AppendLine();
        }
        return sb;
    }

    public StringBuilder GetInventoryContentsLongSb()
    {
        StringBuilder sb = new();
        sb.Append("----------------------------------------\nEquipment:\n----------------------------------------\n");
        foreach (IItem item in _inventory)
        {
            sb.Append(item.Name).Append(" \t- ").Append(item.Description).AppendLine();
        }
        sb.Append("\n----------------------------------------\n");

        return sb;
    }

    public StringBuilder GetHpSb()
    {
        int percentage = (int)(10.0 * PlayerStats.Health / PlayerStats.MaxHealth);
        StringBuilder sb = new();
        sb.Append($"HP: [{PlayerStats.Health}/{PlayerStats.MaxHealth}]");
        sb.Append("[");
        for (int i = 1; i <= percentage; i++)
        {
            sb.Append("#");
        }
        sb.Append("/");
        for (int i = percentage + 1; i <= 10; i++)
        {
            sb.Append(".");
        }
        sb.Append("]\n");

        return sb;
    }

    public StringBuilder GetStats()
    {
        // public int Strength { get; set; }
        // public int Agility { get; set; }
        // public int Intelligence { get; set; }
        // public int Health { get; set; }
        // public int MaxHealth { get; set; }
        // public int Luck { get; set; }
        // public int Aggresion { get; set; }
        //     
        StringBuilder sb = new();
        sb.AppendLine($"Strength: \t\t{PlayerStats.Strength}");
        sb.AppendLine($"Agility: \t\t{PlayerStats.Agility}");
        sb.AppendLine($"Intelligence: \t\t{PlayerStats.Intelligence}");
        // sb.AppendLine($"Health: \t{PlayerStats.Health}");
        // sb.AppendLine($"Max Health: \t{PlayerStats.MaxHealth}");
        sb.AppendLine($"Luck: \t\t\t{PlayerStats.Luck}");
        sb.AppendLine($"Aggresion: \t\t{PlayerStats.Aggresion}");
        return sb;
    }
    
    public bool Move(int y, int x)
    {
        PosX += x;
        PosY += y;
        return true;
    }

    public StringBuilder GetHandsContent()
    {
        StringBuilder sb = new();
        switch (_hands)
        {
            case HandsUsability.LeftUsed:
                sb.AppendLine("In left hand i wield: " + LeftHand?.Name);
                break;
            case HandsUsability.RightUsed:
                sb.AppendLine("In right hand i wield: " + RightHand?.Name);
                break;
            case HandsUsability.NoneUsed:
                sb.AppendLine("Im goly i wesoly");
                break;
            case HandsUsability.BothUsed:
                sb.AppendLine("I wield " + LeftHand?.Name  + " in my left hand and " + RightHand?.Name + " in my right hand.");
                break;
            case HandsUsability.TwoHanded:
                sb.AppendLine("I wield two handed weapon " + RightHand?.Name ?? "error");
                break;
        }
        return sb;
    }
}