using System.Security.Cryptography;
using DungeonLabMaster.Items;

namespace DungeonLabMaster.Map.FactoryDep;

public interface IFactoryDep
{
    protected static int _counter = 0;
    public IItem Create();
}