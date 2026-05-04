using DungeonLabMaster.Items;
using DungeonLabMaster.MovableEntities;
using DungeonLabMaster.MovableEntities.Enemy;

namespace DungeonLabMaster.Map;

public class DungeonMapBuilder: IDungeonMapBuilder
{
    bool _enemysAreStactionary;
    private List<IAliveEntity> _enemies = new List<IAliveEntity>();
    private bool _valid = false;
    private int  _width, _height;
    private Tile [,]? _dungeonMap;
    private List<string> _helpTextList;
    // change to make enemeis move
    public DungeonMapBuilder(int height = 20, int width = 40, bool enemysAreStactionary = false)
    {
        Console.WriteLine("DungeonMapBuilder -- starting up");
        _width = width;
        _height = height;
        _enemysAreStactionary = enemysAreStactionary;
    }

    public void AddCustomItem(IItem item)
    {
        var (y, x) = GetPositionOfRandomEmptyTile();
        AddItemToMap(y, x, item);
    }
    
    private (int y, int x) GetPositionOfRandomEmptyTile()
    {
        while (true)
        {
            var y = Random.Shared.Next(0, _height);
            var x = Random.Shared.Next(0, _width);
            if(CheckIfTileIsEmpty(y, x) && CheckIfTileIsReachable(y, x)) return (y, x);
        }
    }
    
    public void SetHelpInfo(List<string> helpTextList)
    {
        _helpTextList = helpTextList;
    }
    public Map GetMap()
    {
        TestIfMapIsValid();
        _dungeonMap[0, 0].RemoveWallHere();
        Map finalMap = new Map(_height, _width, _dungeonMap,  new Player(), _helpTextList, _enemies, _enemysAreStactionary);
        finalMap.addEnemiesRefToMap();
        return finalMap;
    }

    private void TestIfMapIsValid()
    {
        if (!_valid)
        {
            throw new InvalidOperationException("Map must be first uninitialized");
        }
    }

    private void BuilderMapInicializer()
    {
        _dungeonMap = new Tile[_height, _width];
        for (int y = 0; y < _height; y++)
        {
            for (int x = 0; x < _width; x++)
            {
                _dungeonMap[y, x] = new Tile();
            }
        }
    }
    
    public void BuildBaseMapEmpty()
    {
        if(!_valid) BuilderMapInicializer();
        else
        {
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    _dungeonMap[y, x].BuilderSetEmptyHere();
                }
            }
        }
        
        _valid = true;
    }

    public void BuildBaseMapFull()
    {
        if(!_valid) BuilderMapInicializer();
        
        for (int y = 0; y < _height; y++)
        {
            for (int x = 0; x < _width; x++)
            {
                _dungeonMap[y, x].BuilderSetWallHere();
            }
        }
        _dungeonMap[0, 0].RemoveWallHere();
        _valid = true;
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
    
    
    public void ConnectAllRooms()
    {
        List<Room> rooms = FindAllRooms();
        if (rooms.Count < 2) return;
        
        for (int i = 0; i < rooms.Count - 1; i++)
        {
            ConnectRooms(rooms[i], rooms[i + 1]);
        }
    }

    private List<Room> FindAllRooms()
    {
        var rooms = new List<Room>();
        var visited = new bool[_height, _width];
        
        for (int y = 0; y < _height; y++)
        {
            for (int x = 0; x < _width; x++)
            {
                if (!IsWall(y, x) && !visited[y, x])
                {
                    var room = FloodFillRoom(y, x, visited);
                    if (room.MaxX - room.MinX > 3 && room.MaxY + room.MinY >= 3)
                    {
                        rooms.Add(room);
                    }
                }
            }
        }
        return rooms;
    }
    private Room FloodFillRoom(int startY, int startX, bool[,] visited)
    {
        var room = new Room();
        var queue = new Queue<(int y, int x)>();
        queue.Enqueue((startY, startX));
        visited[startY, startX] = true;
    
        while (queue.Count > 0)
        {
            var (y, x) = queue.Dequeue();
            room.Tiles.Add((y, x));
        
            room.MinX = Math.Min(room.MinX, x);
            room.MaxX = Math.Max(room.MaxX, x);
            room.MinY = Math.Min(room.MinY, y);
            room.MaxY = Math.Max(room.MaxY, y);
        
            foreach (var (dy, dx) in new[] {(-1,0),(1,0),(0,-1),(0,1)})
            {
                int ny = y + dy, nx = x + dx;
                if (ny >= 0 && ny < _height && nx >= 0 && nx < _width && 
                    !IsWall(ny, nx) && !visited[ny, nx])
                {
                    visited[ny, nx] = true;
                    queue.Enqueue((ny, nx));
                }
            }
        }
        return room;
    }
    

    private void ConnectRooms(Room room1, Room room2)
    {
        var (point1, point2) = FindClosestPoints(room1, room2);
        CarveTunnel(point1.y, point1.x, point2.y, point2.x);
        WidenTunnel(point1.y, point1.x, point2.y, point2.x);
    }

    private ((int y, int x), (int y, int x)) FindClosestPoints(Room room1, Room room2)
    {
        double minDistance = double.MaxValue;
        (int y, int x) best1 = (0, 0);
        (int y, int x) best2 = (0, 0);
        
        var edges1 = GetEdgePoints(room1);
        var edges2 = GetEdgePoints(room2);
        
        foreach (var p1 in edges1)
        {
            foreach (var p2 in edges2)
            {
                double dist = Math.Abs(p1.x - p2.x) + Math.Abs(p1.y - p2.y);
                if (dist < minDistance)
                {
                    minDistance = dist;
                    best1 = p1;
                    best2 = p2;
                }
            }
        }
        
        return (best1, best2);
    }

    private List<(int y, int x)> GetEdgePoints(Room room)
    {
        var edges = new List<(int y, int x)>();
        
        foreach (var (y, x) in room.Tiles)
        {
            bool isEdge = false;
            foreach (var (dy, dx) in new[] {(-1,0),(1,0),(0,-1),(0,1)})
            {
                int ny = y + dy, nx = x + dx;
                if (ny < 0 || ny >= _height || nx < 0 || nx >= _width || IsWall(ny, nx))
                {
                    isEdge = true;
                    break;
                }
            }
            
            if (isEdge)
                edges.Add((y, x));
        }
        
        var sampled = new List<(int y, int x)>();
        for (int i = 0; i < edges.Count; i += 3)
            sampled.Add(edges[i]);
        
        return sampled.Count > 0 ? sampled : edges;
    }

    private void CarveTunnel(int y1, int x1, int y2, int x2)
    {
        bool horizontalFirst = Random.Shared.Next(2) == 0;
        
        if (horizontalFirst)
        {
            for (int x = Math.Min(x1, x2); x <= Math.Max(x1, x2); x++)
                RemoveWallTileFromMap(y1, x);
            
            for (int y = Math.Min(y1, y2); y <= Math.Max(y1, y2); y++)
                RemoveWallTileFromMap(y, x2);
        }
        else
        {
            for (int y = Math.Min(y1, y2); y <= Math.Max(y1, y2); y++)
                RemoveWallTileFromMap(y, x1);
            
            for (int x = Math.Min(x1, x2); x <= Math.Max(x1, x2); x++)
                RemoveWallTileFromMap(y2, x);
        }
    }

    private void WidenTunnel(int y1, int x1, int y2, int x2)
    {
        var random = Random.Shared;
        
        if (Math.Abs(x1 - x2) > Math.Abs(y1 - y2))
        {
            int offsetY = y1 + (random.Next(2) == 0 ? 1 : -1);
            if (offsetY >= 0 && offsetY < _height)
            {
                for (int x = Math.Min(x1, x2); x <= Math.Max(x1, x2); x++)
                    RemoveWallTileFromMap(offsetY, x);
            }
        }
        else
        {
            int offsetX = x1 + (random.Next(2) == 0 ? 1 : -1);
            if (offsetX >= 0 && offsetX < _width)
            {
                for (int y = Math.Min(y1, y2); y <= Math.Max(y1, y2); y++)
                    RemoveWallTileFromMap(y, offsetX);
            }
        }
    }

    private class Room
    {
        public List<(int y, int x)> Tiles = new List<(int y, int x)>();
        public int MinX = int.MaxValue, MaxX = int.MinValue;
        public int MinY = int.MaxValue, MaxY = int.MinValue;
    } 
    
    // ========================================================================

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
        // AddCorridorsStructured(count);
        ConnectAllRooms();
        AddCorridorsRand(count);
    }
    
   
    private List<(Rectangle, Rectangle)> CreateMinimumSpanningTree(List<Rectangle> rooms)
    {
        var edges = new List<(int r1, int r2, int distance)>();
        
        // Calculate all possible connections
        for (int i = 0; i < rooms.Count; i++)
        {
            for (int j = i + 1; j < rooms.Count; j++)
            {
                int dist = GetRoomDistance(rooms[i], rooms[j]);
                edges.Add((i, j, dist));
            }
        }
        
        // Sort by distance
        edges = edges.OrderBy(e => e.distance).ToList();
        
        // Kruskal's algorithm for MST
        var parent = Enumerable.Range(0, rooms.Count).ToArray();
        var mst = new List<(Rectangle, Rectangle)>();
        
        int Find(int x)
        {
            if (parent[x] != x)
                parent[x] = Find(parent[x]);
            return parent[x];
        }
        
        foreach (var (r1, r2, _) in edges)
        {
            int root1 = Find(r1);
            int root2 = Find(r2);
            
            if (root1 != root2)
            {
                parent[root2] = root1;
                mst.Add((rooms[r1], rooms[r2]));
                if (mst.Count == rooms.Count - 1) break;
            }
        }
        
        return mst;
    }

    private int GetRoomDistance(Rectangle room1, Rectangle room2)
    {
        // Manhattan distance between room centers
        int centerX1 = room1.X + room1.Width / 2;
        int centerY1 = room1.Y + room1.Height / 2;
        int centerX2 = room2.X + room2.Width / 2;
        int centerY2 = room2.Y + room2.Height / 2;
        
        return Math.Abs(centerX1 - centerX2) + Math.Abs(centerY1 - centerY2);
    }

    private void AddOrthogonalCorridor(Rectangle room1, Rectangle room2)
    {
        var random = Random.Shared;
        
        // Get connection points from room edges
        var points1 = GetRoomEdgePoints(room1);
        var points2 = GetRoomEdgePoints(room2);
        
        // Find closest points between rooms
        (int x1, int y1) = points1.OrderBy(p => ManhattanDistance(p, points2.First())).First();
        (int x2, int y2) = points2.OrderBy(p => ManhattanDistance(p, (x1, y1))).First();
        
        // Create L-shaped or Z-shaped corridor for variety
        bool useHorizontalFirst = random.Next(2) == 0;
        
        if (useHorizontalFirst)
        {
            // Horizontal then vertical
            int midY = y1;
            for (int x = Math.Min(x1, x2); x <= Math.Max(x1, x2); x++)
                RemoveWallTileFromMap(midY, x);
            
            int xEnd = x2;
            for (int y = Math.Min(y1, y2); y <= Math.Max(y1, y2); y++)
                RemoveWallTileFromMap(y, xEnd);
        }
        else
        {
            // Vertical then horizontal
            int midX = x1;
            for (int y = Math.Min(y1, y2); y <= Math.Max(y1, y2); y++)
                RemoveWallTileFromMap(y, midX);
            
            int yEnd = y2;
            for (int x = Math.Min(x1, x2); x <= Math.Max(x1, x2); x++)
                RemoveWallTileFromMap(yEnd, x);
        }
        
        // Corridor widening (optional - for bigger dungeons)
        if (random.NextDouble() < 0.3) // 30% chance for wider corridors
            WidenCorridor(x1, y1, x2, y2);
    }

    private List<(int x, int y)> GetRoomEdgePoints(Rectangle room)
    {
        var points = new List<(int x, int y)>();
        
        // Add points from all four edges with some spacing
        for (int x = room.X; x <= room.X + room.Width; x += Math.Max(1, room.Width / 3))
        {
            points.Add((x, room.Y)); // Top edge
            points.Add((x, room.Y + room.Height)); // Bottom edge
        }
        
        for (int y = room.Y; y <= room.Y + room.Height; y += Math.Max(1, room.Height / 3))
        {
            points.Add((room.X, y)); // Left edge
            points.Add((room.X + room.Width, y)); // Right edge
        }
        
        return points.Distinct().ToList();
    }

    private int ManhattanDistance((int x, int y) p1, (int x, int y) p2)
    {
        return Math.Abs(p1.x - p2.x) + Math.Abs(p1.y - p2.y);
    }

    private void WidenCorridor(int x1, int y1, int x2, int y2)
    {
        // Add parallel corridor adjacent to the main one
        // This creates 2-tile wide corridors in some places
        int offset = Random.Shared.Next(2) == 0 ? 1 : -1;
        
        if (Math.Abs(x1 - x2) > Math.Abs(y1 - y2))
        {
            // Horizontal corridor
            for (int x = Math.Min(x1, x2); x <= Math.Max(x1, x2); x++)
                RemoveWallTileFromMap(y1 + offset, x);
        }
        else
        {
            // Vertical corridor
            for (int y = Math.Min(y1, y2); y <= Math.Max(y1, y2); y++)
                RemoveWallTileFromMap(y, x1 + offset);
        }
    }
    private bool IsWall(int y, int x)
    {
        return _dungeonMap[y, x].NotAWallOrATrap;
    }
    public class Rectangle
    {
        public int X, Y, Width, Height;
        public int CenterX => X + Width / 2;
        public int CenterY => Y + Height / 2;
        
        public Rectangle(int x, int y, int width, int height)
        {
            X = x; Y = y; Width = width; Height = height;
        }
    }
    
// ========================================================================

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

    public void AddItems(int numberOfItems, IDungeonItemFactory factory)
    {
        TestIfMapIsValid();
        for (int i = 0; i < numberOfItems; i++)
        {
            (int y, int x) = GetPositionOfRandomEmptyTile();
            AddItemToMap(y, x, factory.CreateNewRandomItem());
        }
    }

    public void AddWeapon(int numberOfWeapons, IDungeonItemFactory factory)
    {
        TestIfMapIsValid();
        for (int i = 0; i < numberOfWeapons; i++)
        {
            (int y, int x) = GetPositionOfRandomEmptyTile();
            AddItemToMap(y, x, factory.CreateNewRandomWeapon());
        }
    }
    public void AddEnemies(int numberOfEnemiesN, IEnemyFactory factory)
    {
        for (int i = 0; i < numberOfEnemiesN; i++)
        {
            var pos =  GetPositionOfRandomEmptyTile();
            IAliveEntity g = factory.CreateEnemy(pos.y, pos.x);
            _enemies.Add(g);
        }
    }
    
    
// ========================================================================

    private bool CheckIfPositionIsOnMap(int y, int x)
    {
        return x >= 0 && x < _width && y >= 0 && y < _height;
    }

    private bool CheckIfTileIsReachable(int y, int x)
    {
        return CheckIfPositionIsOnMap(y, x) && _dungeonMap[y, x].NotAWallOrATrap;
    }

    private bool CheckIfTileIsEmpty(int y, int x)
    {
        return _dungeonMap[y, x].IsEmpty;
    }
    
    public bool AddItemToMap(int y, int x, IItem item)
    {  
        if (!CheckIfTileIsReachable(y, x)) return false;
        return _dungeonMap[y, x].PutItemHere(item);
    }
    public bool RemoveWallTileFromMap(int y, int x)
    {
        if(!CheckIfPositionIsOnMap(y, x)) return false;
        return _dungeonMap[y, x].RemoveWallHere();
    }

    public bool AddWallToMap(int y, int x)
    {
        if(!CheckIfPositionIsOnMap(y, x) || !CheckIfTileIsEmpty(y, x)) return false;
        return _dungeonMap[y, x].PutWallHere();
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
                _dungeonMap[y, x].RemoveWallHere();
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