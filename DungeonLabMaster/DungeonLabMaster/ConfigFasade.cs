using System.Text.Json;

namespace DungeonLabMaster;

public class ConfigFasade
{
    public static GameConfig Load(string ConfigFilePath)
    {
        var config = new GameConfig();
        if (File.Exists(ConfigFilePath))
        {
            var json = File.ReadAllText(ConfigFilePath);
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
        }
        return config;
    }
}