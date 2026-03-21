using DungeonLabMaster.Items;
using DungeonLabMaster.MovableEntities;

namespace DungeonLabMaster.Map;

public class DungeonMapBuilder: IDungeonMapBuilder
{
    bool valid = false;
    private int  _width, _height;
    private Tile [,]? _DungeonMap;
    private DungeonItemFactory _DungeonItemFactory;
    private List<string> _helpTextList;
    public DungeonMapBuilder(int height = 20, int width = 40)
    {
        Console.WriteLine("DungeonMapBuilder -- starting up");
        _width = width;
        _height = height;
        _DungeonItemFactory = new DungeonItemFactory();
    }

    private (int y, int x) getPositionOfRandomEmptyTile()
    {
        while (true)
        {
            var y = Random.Shared.Next(0, _height);
            var x = Random.Shared.Next(0, _width);
            if(CheckIfTileIsEmpty(y, x) && CheckIfTileIsReachable(y, x)) return (y, x);
        }
    }

    public void setHelpInfo(List<string> helpTextList)
    {
        _helpTextList = helpTextList;
    }
    public Map GetMap()
    {
        TestIfMapIsValid();
        _DungeonMap[0, 0].RemoveWallHere();
        Map _FinalMap = new Map(_height, _width, _DungeonMap,  new Player(), _helpTextList);
        return _FinalMap;
    }

    private void TestIfMapIsValid()
    {
        if (!valid)
        {
            throw new InvalidOperationException("Map must be first uninitialized");
        }
    }

    private void BuilderMapInicializer()
    {
        _DungeonMap = new Tile[_height, _width];
        for (int y = 0; y < _height; y++)
        {
            for (int x = 0; x < _width; x++)
            {
                _DungeonMap[y, x] = new Tile();
            }
        }
    }
    
    public void BuildBaseMapEmpty()
    {
        if(!valid) BuilderMapInicializer();
        else
        {
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    _DungeonMap[y, x].BuilderSetEmptyHere();
                }
            }
        }
        
        valid = true;
    }

    public void BuildBaseMapFull()
    {
        if(!valid) BuilderMapInicializer();
        
        for (int y = 0; y < _height; y++)
        {
            for (int x = 0; x < _width; x++)
            {
                _DungeonMap[y, x].BuilderSetWallHere();
            }
        }
        
        valid = true;
    }

    public void AddCorridorsRand(int count)
    {
        int minLen = 12, maxLen = 40;
        TestIfMapIsValid();
        var random = Random.Shared;
        for (int i = 0; i < count; i++)
        {
            int x =  random.Next(0, _width);
            int y =  random.Next(0, _height);
            
            int length = random.Next(minLen, maxLen);

            for (int step = 0; step < length; step++)
            {
                RemoveWallTileFromMap(y, x);
                int moveTo = random.Next(0, 4);
                switch (moveTo)
                {
                    case 0: y = Math.Clamp(y - 1, 0, _height - 1); break;
                    case 1: y = Math.Clamp(y + 1, 0, _height - 1); break;
                    case 2: x = Math.Clamp(x - 1, 0, _width - 1); break;
                    case 3: x = Math.Clamp(x+1, 0 , _width - 1); break;
                }
            }
        }
    }

    public void AddCorridorsL(int count)
    {
        TestIfMapIsValid();
        var random = Random.Shared;

        for (int i = 0; i < count; i++)
        {
            int x1 = random.Next(0, _width);
            int y1 = random.Next(0, _height);
            int x2 = random.Next(0, _width);
            int y2 = random.Next(0, _height);

            int xStep = Math.Sign(x2 - x1);
            for (int x = x1; x != x2; x += xStep)
            {
                RemoveWallTileFromMap(y1, x);
            }

            int yStep = Math.Sign(y2 - y1);
            for (int y = y1; y != y2; y += yStep)
            {
                RemoveWallTileFromMap(y, x2);
            }
        }
    }
    public void AddCorridorL(int y1, int x1, int y2, int x2)
    {
        TestIfMapIsValid();

        int xStep = Math.Sign(x2 - x1);
        for (int x = x1; x != x2; x += xStep)
        {
            RemoveWallTileFromMap(y1, x);
        }
        int yStep = Math.Sign(y2 - y1);
        for (int y = y1; y != y2; y += yStep)
        {
            RemoveWallTileFromMap(y, x2);
        }
    }

    public void AddCorridors(int count)
    {
        AddCorridorsL(count / 2);
        AddCorridorsRand((count+1) / 2);
    }

    public void AddRooms(int count)
    {
        TestIfMapIsValid();
        int roomSize = 2;
        for (int i = 0; i < count; i++)
        {
            int x  = Random.Shared.Next(0, _width);
            int y  = Random.Shared.Next(0, _height);
            AddCorridorL(0, 0, y, x);
            DrawEmptyRoomInMap(y, x, y+roomSize, x+roomSize);
        }
    }

    public void AddCentralHall(int height, int width)
    {
        TestIfMapIsValid();
        AddCorridorL(0, 0, height , width );
        int roomSize = Math.Min(height, width) / 4;
        DrawEmptyRoomInMap(height- roomSize, width-roomSize, height+roomSize, width+roomSize );

    }

    public void AddItems(int numberOfItems, DungeonItemFactory factory)
    {
        TestIfMapIsValid();
        for (int i = 0; i < numberOfItems; i++)
        {
            (int y, int x) = getPositionOfRandomEmptyTile();
            AddItemToMap(y, x, factory.CreateNewRandomItem());
        }
    }

    public void AddWeapon(int numberOfWeapons, DungeonItemFactory factory)
    {
        TestIfMapIsValid();
        for (int i = 0; i < numberOfWeapons; i++)
        {
            (int y, int x) = getPositionOfRandomEmptyTile();
            AddItemToMap(y, x, factory.CreateNewRandomWeapon());
        }
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
    public bool RemoveWallTileFromMap(int y, int x)
    {
        if(!CheckIfPositionIsOnMap(y, x)) return false;
        return _DungeonMap[y, x].RemoveWallHere();
    }

    public bool AddWallToMap(int y, int x)
    {
        if(!CheckIfPositionIsOnMap(y, x) || !CheckIfTileIsEmpty(y, x)) return false;
        return _DungeonMap[y, x].PutWallHere();
    }
    public bool DrawWallStraightLineToDungeonMap(int x1, int y1, int x2, int y2)
    {
        if(!CheckIfPositionIsOnMap(y1, x1) && !CheckIfPositionIsOnMap(y2, x2)) return false;
        if (x1 == x2)
        {
            for (int y = y1; y <= y2; y++)
            {
                AddWallToMap(y,  x1);
            }
            return true;
        } 
        else if (y1 == y2)
        {
            for (int x = x1; x <= x2; x++)
            {
                AddWallToMap(y1, x);
            }
            return true;
        }
        return false;
    }

    public bool DrawWallSquareToDungeonMap(int y1, int x1, int y2, int x2)
    {
        // if(!CheckIfPositionIsOnMap(y1, x1)) return false;
        // if(!CheckIfPositionIsOnMap(y2, x2)) return false;
        
        if (x1 > x2)
        {
            (x1, x2) = (x2, x1);
        }
        if (y1 > y2)
        {
            (y1, y2) = (y2, y1);
        }
        
        DrawWallStraightLineToDungeonMap(x1, y1, x2, y1);
        DrawWallStraightLineToDungeonMap(x1, y2, x2, y2);
        DrawWallStraightLineToDungeonMap(x1, y1, x1, y2);
        DrawWallStraightLineToDungeonMap(x2, y1, x2, y2);
        return true;
    }

    public bool DrawRoomToDungeonMap(int y1, int x1, int y2, int x2)
    {
        // if(!CheckIfPositionIsOnMap(y1, x1)) return false;
        // if(!CheckIfPositionIsOnMap(y2, x2)) return false;
        
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
    public bool DrawEmptyRoomInMap(int y1, int x1, int y2, int x2)
    {
        for (int y = y1; y <= y2; y++)
        {
            for (int x = x1; x <= x2; x++)
            {
                RemoveWallTileFromMap(y, x);
            }
        }

        return true;
    }
    
}