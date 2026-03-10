using DungeonLabMaster.Items;

namespace DungeonLabMaster.Map;

public struct Tile
{
    public char PrintValue {get; private set;}
    public IItem? Item {get; private set;}
    public bool NotAWallOrATrap {get; private set;}
    public bool IsEmpty {get; private set;}

    public Tile()
    {
        PrintValue = '.';
        Item = null;
        NotAWallOrATrap = true;
        IsEmpty = true;
    }

    public bool PutItemHere(IItem item)
    {
        if (!IsEmpty || !NotAWallOrATrap) return false;
        IsEmpty = false;
        Item = item;
        PrintValue = item.ItemMapName;
        return true;
    }

    public bool PutWallHere()
    {
        if (!IsEmpty) return false;
        PrintValue = '#';
        NotAWallOrATrap = false;
        return true;
    }

    public bool RemoveWallHere()
    {
        if(!NotAWallOrATrap) return false;
        PrintValue = '.';
        IsEmpty = true;
        NotAWallOrATrap = false;
        return true;
    }
    
    public IItem? RemoveItemFromHere()
    {
        // wiem ze nie wolno kozystac z is, ale to nie pelni tu zadnej roli i jest tylko po to by uciszcyc warniig
        if (IsEmpty || Item is null) return null;
        IItem tmp = Item;
        Item = null;
        PrintValue = '.';
        IsEmpty = true;
        return tmp;
    }
}