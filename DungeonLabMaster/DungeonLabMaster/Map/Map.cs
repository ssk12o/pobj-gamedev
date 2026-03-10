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
    private IPlayerEnt _player;

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

        // _playerEnts = new List<IPlayerEnt>();
        _player = new Player();
    }

    private bool CheckIfPositionIsInMap(int y, int x)
    {
        return x >= 0 && x < _width && y >= 0 && y < _height;
    }

    private bool CheckIfTileIsReachable(int y, int x)
    {
        return CheckIfPositionIsInMap(y, x) && _DungeonMap[y, x].NotAWallOrATrap;
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
    
    public bool RemoveWallFromMap(int y, int x)
    {
        if(CheckIfTileIsReachable(y, x)) return false;
        return _DungeonMap[y, x].RemoveWallHere();
    }

    public bool DrawStraightWallLine(int x1, int y1, int x2, int y2)
    {
        if(!CheckIfTileIsReachable(x1, y1) || !CheckIfPositionIsInMap(x2, y2)) return false;
        if (x1 == x2)
        {
            for (int y = y1; y <= y2; y++)
            {
                _DungeonMap[y, x1].PutWallHere();
            }
            return true;
        } else if (y1 == y2)
        {
            for (int x = x1; x <= x2; x++)
            {
                _DungeonMap[y1, x].PutWallHere();
                
            }
            return true;
        }
        return false;
    }
    

    public void PrintMap()
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
        
        
        Console.Clear();
        Console.WriteLine($"DungeonLabMaster map after round {_movementRound++}");
        Console.WriteLine(sb.ToString());
    }
}