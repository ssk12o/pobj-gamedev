namespace DungeonLabMaster.MovableEntities;

public class Pathfinding
{
    public static int CalculateDistance(Map.Map map, int x1, int y1, int x2, int y2)
    {
        if (map == null || x1 == x2 && y1 == y2) return 0;
        
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
                
                if (nx >= 0 && nx < map.GetWidth && 
                    ny >= 0 && ny < map.GetHeight &&
                    !map.CheckIfTileIsReachable(ny, nx) &&
                    !visited.Contains((nx, ny)))
                {
                    visited.Add((nx, ny));
                    queue.Enqueue((nx, ny, current.distance + 1));
                }
            }
        }
        
        return int.MaxValue;
    }

    public static bool CanReach(Map.Map map, int x1, int y1, int x2, int y2, int maxDistance)
    {
        int distance = CalculateDistance(map, x1, y1, x2, y2);
        return distance <= maxDistance;
    }
}