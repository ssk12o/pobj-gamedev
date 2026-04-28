using System.Text;
using DungeonLabMaster.Items;
using DungeonLabMaster.Items.Weapons;
using DungeonLabMaster.Logging;
using DungeonLabMaster.SoundPropagation;

namespace DungeonLabMaster.MovableEntities;

public class Player: IAliveEntity
{
    public string Name { get; } = "Gamer_you";
    public char MapChar { get; }

    public int PosX { get; set; }
    public int PosY { get; set; }
    
    public int GoldCount { get; private set; } = 0;
    public int CoinCount { get; private set; } = 0;
    public IAliveEntity.PlayerStatsT Playerstats { get; protected set; }


    
    private List<IItem> _inventory;
    public int NumberOfItemsInEquipment => _inventory.Count;
    public IItem[] Hands { get; set; } = new IItem[2];
    

    public Player(int health = 100, int posY = 0, int posX = 0, string name = "Player",
        char mapChar = 'P', List<IItem>? startingInventory = null)
    {
        Playerstats = new IAliveEntity.PlayerStatsT();
        Playerstats.Health = Playerstats.MaxHealth = health;
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
        int itemNewIndex = -1;
        Console.WriteLine("Chose which hand is to wield this item. R or L or Backspace");
        bool spin = true;
        while (spin)
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.R:
                    itemNewIndex = 0;
                    spin = false;
                    break;
                case ConsoleKey.L:
                    itemNewIndex = 1;
                    spin = false;
                    break;
                case ConsoleKey.Backspace:
                    return;
            }
        }
        
        switch (item.Handness)
        {
            case 2:
                AddItemToEquipment(Hands[0]);
                AddItemToEquipment(Hands[1]);
                Hands[itemNewIndex] = item;
                Hands[1 -  itemNewIndex] = null;
                break;
            case 1:
                AddItemToEquipment(Hands[itemNewIndex]);
                Hands[itemNewIndex] = item;
                break;
        }
        
        
        SoundSingleton.Instance.Emitter.NotifySound(PosY, PosX, item.GetSoundValueAfterAction(Playerstats));
        Logger.Instance.Log($"Player handed {item.Name}", ELogCategory.HandInfo);
    }
    public void UnhandItem()
    {
        Console.WriteLine("Chose which hand is to be emptied: R or L or Backspace");
        bool spin = true;
        while (spin)
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.R:
                    AddItemToEquipment(Hands[0]);
                    Logger.Instance.Log($"Player unhanded {Hands[0].Name}", ELogCategory.HandInfo);
                    Hands[0] = null;
                    return;
                case ConsoleKey.L:
                    AddItemToEquipment(Hands[1]);
                    Logger.Instance.Log($"Player unhanded {Hands[1].Name}", ELogCategory.HandInfo);
                    Hands[1] = null;
                    return;
                case ConsoleKey.Backspace:
                    return;
            }
        }

    }

    public void AddItemToEquipment(IItem? item)
    {
        if (item == null) return;
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
        Logger.Instance.Log($"Player added {item.Name} to inventory", ELogCategory.InventoryInfo);
    }

    public IItem? RemoveItemNoFromEquipment(int number)
    {
        if(0 >= _inventory.Count || _inventory.Count <= number) return null;
        
        IItem ret = _inventory[number];
        _inventory.RemoveAt(number);
        
        SoundSingleton.Instance.Emitter.NotifySound(PosY, PosX, ret.GetSoundValueAfterAction(Playerstats));
        Logger.Instance.Log($"Player removed {ret.Name} from inventory", ELogCategory.InventoryInfo);
        return ret;
    }

    public StringBuilder GetInventoryListSb()
    {
        int i = 0;
        StringBuilder sb = new StringBuilder();
        foreach (IItem item in _inventory)
        {
            sb.Append($"[{i++}] \t- {item.ItemMapName} - ");
            if (item.IsWeapon)
            {
                // IWeapon wep = (IWeapon)item;
                // sb.Append($"[Attack: {wep.}, Defense: {wep.Defense} \t- ");
                sb.Append($"[Attack: {item.GetDamage(Playerstats)}, Defense: {0} \t- ");
            }

            sb.Append($"{item.Name} \t\t - {item.Description}\n");
        }
        return sb;
    }

    public StringBuilder GetValuables()
    {
        StringBuilder sb = new();
        sb.AppendLine($"Amount of Gold {GoldCount}");
        sb.AppendLine($"Amount of Coin {CoinCount}");
        return sb;
    }

    public StringBuilder GetInventoryContentsLongSb()
    {
        StringBuilder sb = new();
        sb.Append("----------------------------------------\nEquipment:\n----------------------------------------\n");
        sb.Append(GetValuables());
        sb.Append("----------------------------------------\n");
        
        foreach (IItem item in _inventory)
        {
            sb.Append(item.Name).Append(" \t- ").Append(item.Description).AppendLine();
        }
        sb.Append("\n----------------------------------------\n");

        return sb;
    }

    public StringBuilder GetHpSb()
    {
        int percentage = (int)(10.0 * Playerstats.Health / Playerstats.MaxHealth);
        StringBuilder sb = new();
        sb.Append($"HP: [{Playerstats.Health}/{Playerstats.MaxHealth}]");
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

    public IAliveEntity.PlayerStatsT getEffectiveStats()
    {
        IAliveEntity.PlayerStatsT effstats = new IAliveEntity.PlayerStatsT();
        foreach (IItem item in Hands)
        {
            if(item == null) continue;
            effstats = effstats + item.GetStatModifiers();
        }

        return effstats = effstats + Playerstats;
        
    }
    public StringBuilder GetStats()
    {
        IAliveEntity.PlayerStatsT effstats = getEffectiveStats();
         
        StringBuilder sb = new();
        sb.AppendLine($"Strength: \t\t{effstats.Strength}");
        sb.AppendLine($"Agility: \t\t{effstats.Agility}");
        sb.AppendLine($"Intelligence: \t\t{effstats.Intelligence}");
        sb.AppendLine($"Luck: \t\t\t{effstats.Luck}");
        sb.AppendLine($"Aggresion: \t\t{effstats.Aggresion}");
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
        foreach (IItem item in Hands)
        {
            if(item == null) continue;
            if (item.Handness == 2)
            {
                return sb.AppendLine("I wield two handed weapon " + item.Name);
            }
            sb.AppendLine("I wield one handed weapon " +  item.Name);
        }

        if (sb.Length <= 0) sb.AppendLine("I am empty handed");
        return sb;
    }

    public int CalculateAttackDamage(IWeaponVisitor vis)
    {
        IAliveEntity.PlayerStatsT stats = getEffectiveStats();
        int h1 = 0, h2 = 0;
        
        var weapon = Hands[0] as IWeapon;
        if (weapon != null && Hands[0].IsWeapon)
        {
            h1 = weapon.Accept(vis);
        }
        weapon = Hands[1] as IWeapon;
        if (weapon != null && Hands[1].IsWeapon)
        {
            h2 = weapon.Accept(vis);
        }
        
        return Math.Max(h1, h2);
    }

    public int CalculateDefense(IWeaponVisitor vis, IWeapon enemyWeapon)
    {
        return enemyWeapon.GetDefense(vis, Playerstats);
    }
}