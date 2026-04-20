using System.Net;

namespace DungeonLabMaster.Logging;

public class FileLoggerType: ILoggerType
{
    private string _filePath;
    private List<string> _buffer;

    public FileLoggerType(string filePath)
    {
        _filePath = filePath;
        _buffer = new List<string>();
    }
    
    public void Log(string message, ELogCategory category, int gameTurn = -1)
    {
        if (gameTurn == -1)
        {
            _buffer.Add($"[{category}] {message}");
        }
        else
        {
            _buffer.Add($"[{gameTurn}][{category}] {message}");
        }
        
    }

    public void Flush()
    {
        File.AppendAllLines(_filePath, _buffer);
        _buffer.Clear();
    }

    public List<string> ReturnLastNLogs(int n = -1)
    {
        throw new NotSupportedException();
    }
}