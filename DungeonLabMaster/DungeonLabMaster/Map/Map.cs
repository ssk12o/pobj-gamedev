using System.Text;
using DungeonLabMaster.Items;
using DungeonLabMaster.MovableEntities;

namespace DungeonLabMaster.Map;

public class Map
{
    private int _movementRound;
    private int _height, _width;
    private Tile[,] _DungeonMap;
    // private List<IPlayerEnt>  _playerEnts;
    private Player _player;

    public bool TryMoveMainPlayer(int y, int x)
    {
        if(!CheckIfTileIsReachable( _player.PosY +  y, _player.PosX + x)) return false;
        return _player.Move(y, x);
    }

    public Map(int height, int width)
    {
        _width = width;
        _height = height;
        _DungeonMap = new Tile[_height, _width];
        for (int y = 0; y < _height; y++)
        {
            for (int x = 0; x < _width; x++)
            {
                _DungeonMap[y, x] = new Tile();
            }
        }
        _player = new Player();
    }

    // ========================================================================

    private bool CheckIfPositionIsOnMap(int y, int x)
    {
        return x >= 0 && x < _width && y >= 0 && y < _height;
    }

    private bool CheckIfTileIsReachable(int y, int x)
    {
        return CheckIfPositionIsOnMap(y, x) && _DungeonMap[y, x].NotAWallOrATrap;
    }

    private bool CheckIfTileIsEmpty(int y, int x)
    {
        return _DungeonMap[y, x].IsEmpty;
    }
    
    public bool AddItemToMap(int y, int x, IItem item)
    {  
        if (!CheckIfTileIsReachable(y, x)) return false;
        return _DungeonMap[y, x].PutItemHere(item);
    }

    public bool AddWallToMap(int y, int x)
    {
        if(!CheckIfTileIsEmpty(y, x)) return false;
        return _DungeonMap[y, x].PutWallHere();
    }

    public bool DrawWallSquareToDungeonMap(int y1, int x1, int y2, int x2)
    {
        if(!CheckIfPositionIsOnMap(y1, x1)) return false;
        if(!CheckIfPositionIsOnMap(y2, x2)) return false;
        
        if (x1 > x2)
        {
            (x1, x2) = (x2, x1);
        }
        if (y1 > y2)
        {
            (y1, y2) = (y2, y1);
        }
        
        DrawWallStrightLIneToDungeonMap(x1, y1, x2, y1);
        DrawWallStrightLIneToDungeonMap(x1, y2, x2, y2);
        DrawWallStrightLIneToDungeonMap(x1, y1, x1, y2);
        DrawWallStrightLIneToDungeonMap(x2, y1, x2, y2);
        return true;
    }

    public bool DrawRoomToDungeonMap(int y1, int x1, int y2, int x2)
    {
        if(!CheckIfPositionIsOnMap(y1, x1)) return false;
        if(!CheckIfPositionIsOnMap(y2, x2)) return false;
        
        if (x1 > x2)
        {
            (x1, x2) = (x2, x1);
        }
        if (y1 > y2)
        {
            (y1, y2) = (y2, y1);
        }

        for (int y = y1; y <= y2; y++)
        {
            for (int x = x1; x <= x2; x++)
            {
                _DungeonMap[y, x].RemoveWallHere();
            }
        }
        return true;
    }
    
    public bool DrawRemoveWallTileFromMap(int y, int x)
    {
        if(!CheckIfPositionIsOnMap(y, x)) return false;
        return _DungeonMap[y, x].RemoveWallHere();
    }

    public bool DrawWallStrightLIneToDungeonMap(int x1, int y1, int x2, int y2)
    {
        if(!CheckIfPositionIsOnMap(y1, x1) || !CheckIfPositionIsOnMap(y2, x2)) return false;
        if (x1 == x2)
        {
            for (int y = y1; y <= y2; y++)
            {
                AddWallToMap(y,  x1);
            }
            return true;
        } else if (y1 == y2)
        {
            for (int x = x1; x <= x2; x++)
            {
                AddWallToMap(y1, x);
            }
            return true;
        }
        return false;
    }

    // ========================================================================
    private StringBuilder GenerateMapSb()
    {
        StringBuilder sb = new StringBuilder();
        for (int y = 0; y < _height; y++)
        {
            for (int x = 0; x < _width; x++)
            {
                if (y == _player.PosY && x == _player.PosX) sb.Append(_player.MapChar);
                else sb.Append(_DungeonMap[y, x].PrintValue);
            }
            sb.AppendLine();
        }

        return sb;
    }

    private void PrintOverField()
    {
        string name;
        char ch;
        if (_DungeonMap[_player.PosY, _player.PosX].IsEmpty || _DungeonMap[_player.PosY, _player.PosX].Item == null )
        {
            name = "";
            ch = ' ';
        }
        else
        {
            name = _DungeonMap[_player.PosY, _player.PosX].getTopItemName();
            ch = _DungeonMap[_player.PosY, _player.PosX].PrintValue;
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
                      _player.GetInventoryListSb().ToString() +
                      "----------------------------------------\n");
    }

    public bool QueryItemRemoval()
    {
        if (_player.NumberOfItemsInEquipment == 0)
        {
            Console.WriteLine("not enough items");
            Thread.Sleep(1000);
            return false;
        }
        
        int y = _player.PosY;
        int x = _player.PosX;
        if (!_DungeonMap[y, x].IsEmpty)
        {
            Console.WriteLine("Field is not empty");
            return false;
        }
        Console.WriteLine("Print number of item to be removed");
        int itemNumber;
        while(!int.TryParse(Console.ReadLine(), out itemNumber))
        {
            Console.WriteLine("Invalid item number");
        }
        IItem? item = _player.RemoveItemNoFromEquipment(itemNumber);
        if (item != null)
        {
            _DungeonMap[y, x].PutItemHere(item);
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
        
        if(_DungeonMap[y, x].IsEmpty) return false;
        IItem? pickedUp = _DungeonMap[y, x].RemoveItemFromHere();
        
        Console.WriteLine("Put in inventory or try wieldind it? E or W");
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