namespace DungeonLabMaster.MovableEntities;

public class Pathfinding
{
    // private static Lazy<Pathfinding> _instance = new(() => new Pathfinding());
    // private Map.Map _map;
    // public static Pathfinding Instance => _instance.Value;
    //
    // public static void Init(Map.Map map)
    // {
    //     if (_instance == null)
    //     {
    //         _instance = Pathfinding(map);
    //     }
    // }
    //
    // public Pathfinding(Map.Map map)
    // {
    //     _map = map;
    // }
    //
    // private Pathfinding()
    // {
    //     throw new Exception();
    // }
    public static int CalculateDistance( int x1, int y1, int x2, int y2, Map.Map _map)
    {
        if (_map == null || x1 == x2 && y1 == y2) return 0;
        
        var queue = new Queue<(int x, int y, int distance)>();
        var visited = new HashSet<(int, int)>();
        
        queue.Enqueue((x1, y1, 0));
        visited.Add((x1, y1));
        
        int[] dx = { 0, 0, 1, -1 };
        int[] dy = { 1, -1, 0, 0 };
        
        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            
            for (int i = 0; i < 4; i++)
            {
                int nx = current.x + dx[i];
                int ny = current.y + dy[i];
                
                if (nx == x2 && ny == y2)
                {
                    return current.distance + 1;
                }
                
                if (nx >= 0 && nx < _map.GetWidth && 
                    ny >= 0 && ny < _map.GetHeight &&
                    !_map.CheckIfTileIsReachable(ny, nx) &&
                    !visited.Contains((nx, ny)))
                {
                    visited.Add((nx, ny));
                    queue.Enqueue((nx, ny, current.distance + 1));
                }
            }
        }
        
        return int.MaxValue;
    }

    public static bool CanReach(int x1, int y1, int x2, int y2, int maxDistance, Map.Map _map)
    {
        int distance = CalculateDistance(x1, y1, x2, y2, _map);
        return distance <= maxDistance;
    }
}