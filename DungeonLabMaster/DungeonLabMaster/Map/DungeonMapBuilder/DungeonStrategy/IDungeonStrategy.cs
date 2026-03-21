namespace DungeonLabMaster.Map;

public interface IDungeonStrategy: IDungeonHelp
{
    void Construct(IDungeonMapBuilder mapBuilder);
    string GetDescription();
}