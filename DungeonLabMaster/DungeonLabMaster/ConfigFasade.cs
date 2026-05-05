using System.Text.Json;

namespace DungeonLabMaster;

public class ConfigFasade
{
    public static GameConfig Load(string ConfigFilePath)
    {
        var config = new GameConfig();
        var path = Path.Combine(AppContext.BaseDirectory, $"./../../../{ConfigFilePath}");
        if (File.Exists(path))
        {
            var json = File.ReadAllText(path);
            var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;

            if (root.TryGetProperty("playerName", out var name))
            {
                config.PlayerName = name.GetString();
            }
            if(root.TryGetProperty("dungeonTheme", out var theme))
            {
                config.DungeonName = theme.GetString();
            }
            if (root.TryGetProperty("logPath", out var logPath))
            {
                config.LogFilePath = logPath.GetString();
            }

            if (root.TryGetProperty("enemiesMove", out var enemiesMove))
            {
                bool.TryParse(enemiesMove.GetString(), out bool move);
                config.enemiesMove = move;
            }
        }
        return config;
    }
}