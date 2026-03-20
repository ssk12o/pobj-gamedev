namespace DungeonLabMaster.Map;

public class DungeonMapBuilder: IDungeonMapBuilder
{
    bool valid = false;
    private int  _width, _height;
    private Tile [,] _DungeonMap;
    private DungeonItemFactory _DungeonItemFactory;

    public DungeonMapBuilder(int height = 20, int width = 40)
    {
        Console.WriteLine("DungeonMapBuilder -- starting up");
        _width = width;
        _height = height;
        _DungeonItemFactory = new  DungeonItemFactory();
    }

    private void TestIfMapIsValid()
    {
        if (!valid)
        {
            throw new InvalidOperationException("Map must be first unicialized");
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

    public void AddCorridors()
    {
        TestIfMapIsValid();
        throw new NotImplementedException();
    }

    public void AddRooms()
    {
        TestIfMapIsValid();
        throw new NotImplementedException();
    }

    public void AddCentralHall()
    {
        TestIfMapIsValid();
        throw new NotImplementedException();
    }

    public void AddItems()
    {
        TestIfMapIsValid();
        throw new NotImplementedException();
    }

    public void AddWeapon()
    {
        TestIfMapIsValid();
        throw new NotImplementedException();
    }
}