using System.Text;
using DungeonLabMaster.Items;
using DungeonLabMaster.MovableEntities;
using DungeonLabMaster.MovableEntities.Enemy;

namespace DungeonLabMaster.Map;

public class Map
{
    private int _movementRound;
    private int _height, _width;
    private Tile[,] _dungeonMap;
    private List<IAliveEntity> _enemies;
    public List<string> HelpTextList;
    private Player _player;
    public bool playerIsAlive {get; protected set;} = true;

    public bool TryMoveMainPlayer(int y, int x)
    {
        if(!CheckIfTileIsReachable( _player.PosY +  y, _player.PosX + x)) return false;
        return _player.Move(y, x);
    }
    // // ========================================================================

    private bool CheckIfPositionIsOnMap(int y, int x)
    {
        return x >= 0 && x < _width && y >= 0 && y < _height;
    }
    private bool CheckIfTileIsReachable(int y, int x)
    {
        return CheckIfPositionIsOnMap(y, x) && _dungeonMap[y, x].NotAWallOrATrap;
    }
    // // ========================================================================

    public Map(int height, int width)
    {
        _width = width;
        _height = height;
        _dungeonMap = new Tile[_height, _width];
        for (int y = 0; y < _height; y++)
        {
            for (int x = 0; x < _width; x++)
            {
                _dungeonMap[y, x] = new Tile();
            }
        }
        _player = new Player();
    }
    public Map(int height, int width, Tile[,] generatedDungeonMap, Player player,  List<string> helpTextList, List<IAliveEntity> enemies)
    {
        _enemies = enemies;
        _width = width;
        _height = height;
        _dungeonMap = generatedDungeonMap;
        _player = player;
        HelpTextList = helpTextList;
    }

    // // ========================================================================
    private StringBuilder GenerateMapSb()
    {
        int pidx = getSBidxFromXY(_player.PosY, _player.PosX);

        StringBuilder sb = new StringBuilder();
        for (int y = 0; y < _height; y++)
        {
            for (int x = 0; x < _width; x++)
            {
                sb.Append(_dungeonMap[y, x].PrintValue);
            }
            sb.AppendLine();
        }
        
        if (_enemies != null)
        {
            IAliveEntity enemyToBeRmoved = null;
            foreach (IAliveEntity enemy in _enemies)
            {
                int idx = getSBidxFromXY(enemy.PosY, enemy.PosX);
                if (idx == pidx)
                {
                    var combat = new Combat(enemy, _player);
                    combat.arenaFight();
                    if (_player.getEffectiveStats().Health <= 0) playerIsAlive = false;
                    else enemyToBeRmoved = enemy;
                }
                sb[idx] = enemy.MapChar;
            }

            if (enemyToBeRmoved != null) _enemies.Remove(enemyToBeRmoved);
        }

        sb[pidx] = _player.MapChar;

        return sb;
    }

    private int getSBidxFromXY(int y, int x)
    {
        return y * (_width + 1) + x;
    }

    private void PrintOverField()
    {
        string name;
        char ch;
        if (_dungeonMap[_player.PosY, _player.PosX].IsEmpty || _dungeonMap[_player.PosY, _player.PosX].Item == null )
        {
            name = "";
            ch = ' ';
        }
        else
        {
            name = _dungeonMap[_player.PosY, _player.PosX].GetTopItemName();
            ch = _dungeonMap[_player.PosY, _player.PosX].PrintValue;
        }
        StringBuilder sb = new StringBuilder();
        sb.Append("[").Append(ch).Append("] ").Append(name);
        if(name != "") sb.Append("\t- press E to equip ");
        Console.Write(sb.AppendLine().ToString());
    }

    private void PrintPlayerStatsAndWeaponsAndInventory()
    {
        Console.Write("----------------------------------------\n" +
                      _player.GetHpSb().ToString() +
                      _player.GetHandsContent().ToString() +
                      "----------------------------------------\n" +
                      _player.GetStats().ToString() + 
                      "----------------------------------------\n" +
                      _player.GetValuables().ToString() + 
                      // _player.GetInventoryListSb().ToString() +
                      "----------------------------------------\n");
    }

    public bool QueryItemRemoval()
    {
        if (_player.NumberOfItemsInEquipment == 0 && _player.Hands[0] == null && _player.Hands[1] == null)
        {
            Console.WriteLine("Inventory is empty!");
            Thread.Sleep(1000);
            return false;
        }
        
        int y = _player.PosY;
        int x = _player.PosX;
        if (!_dungeonMap[y, x].IsEmpty)
        {
            Console.WriteLine("Field is not empty");
            return false;
        }
        Console.WriteLine("Print number of item to be removed, negative number to unhand item or backspace to back out");
        int itemNumber;
        ConsoleKeyInfo keyInfo;
        
        while(true)
        {   
            keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.Backspace) return true;

            if (int.TryParse(Console.ReadLine(), out itemNumber))
            {
                break;
            }
            Console.WriteLine("Invalid item number");
        }

        if (itemNumber < 0)
        {
            _player.UnhandItem();
            return true;
        }
        IItem? item = _player.RemoveItemNoFromEquipment(itemNumber);
        if (item != null)
        {
            _dungeonMap[y, x].PutItemHere(item);
        }

        return true;
    }

    public void PrintRound()
    {
        Console.Clear();
        Console.Write($"DungeonLabMaster after round {_movementRound++}:\n" + GenerateMapSb().ToString());
        PrintOverField();
        PrintPlayerStatsAndWeaponsAndInventory();
        
    }

    public bool PlayerTryPickUpItem()
    {
        int y = _player.PosY;
        int x = _player.PosX;
        
        if(_dungeonMap[y, x].IsEmpty) return false;
        IItem? pickedUp = _dungeonMap[y, x].RemoveItemFromHere();
        
        Console.WriteLine("Put in inventory or try wielding it? E or W");
        bool spin = true;
        while (spin)
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.E:
                    spin = false;
                    _player.AddItemToEquipment(pickedUp);
                    break;
                case ConsoleKey.W:
                    spin = false;
                    _player.HandItem(pickedUp);
                    break;
            }
        }
        return true;
    }

    public void PlayerPrintEquipmentLong()
    {
        Console.Clear();
        Console.Write(_player.GetInventoryContentsLongSb().ToString());
    }
}