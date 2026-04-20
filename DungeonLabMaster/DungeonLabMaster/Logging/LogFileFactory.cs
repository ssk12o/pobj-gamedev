namespace DungeonLabMaster;

public class LogFileFactory
{
    public static string CreateUniqueLogPath(string directoryPath, string playerName)
    {
        var times = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
        var name = new string(playerName.Where(c => char.IsLetter(c) || c == '_').ToArray());
        
        name = $"{times}_{name}";
        var fullPath = Path.Combine(directoryPath, name);
        Directory.CreateDirectory(directoryPath);
        if (File.Exists(fullPath))
        {
            return CreateUniqueLogPath(directoryPath, $"{name}_{Random.Shared.Next()}");
        }

        return fullPath;
    }
}