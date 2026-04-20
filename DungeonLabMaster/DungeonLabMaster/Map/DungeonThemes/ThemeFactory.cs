using DungeonLabMaster.Logging;

namespace DungeonLabMaster.DungeonThemes;

public class ThemeFactory
{
    private static Dictionary<string, IDungeonTheme> _themes = new Dictionary<string, IDungeonTheme>(
        StringComparer.OrdinalIgnoreCase)
        {
            { "library", new LibraryTheme() },
            { "factory", new FactoryTheme() },
            { "bank", new BankTheme() },
        };

    public static IDungeonTheme GetTheme(string name)
    {
        if (_themes.TryGetValue(name, out var theme))
        {
            return theme;
        }
        
        Logger.Instance.Log($"Unknown theme '{name}'", ELogCategory.Other);
        return new LibraryTheme();
    }

    public static List<string> GetThemes()
    {
        return _themes.Keys.ToList();
    }
}