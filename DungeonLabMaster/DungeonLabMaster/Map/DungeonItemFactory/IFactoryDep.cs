using System.Security.Cryptography;
using DungeonLabMaster.Items;

namespace DungeonLabMaster.Map.FactoryDep;

public interface IFactoryDep
{
    protected static int Counter = 0;
    public IItem Create();
}