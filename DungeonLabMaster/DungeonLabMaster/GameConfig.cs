namespace DungeonLabMaster;

public class GameConfig
{
    public string PlayerName {get; set;} = "Unknown";
    public string DungeonName {get; set;} = "library";
    public string LogFilePath { get; set; } = "logs/";
    public bool enemiesMove {get; set;} = false;
}