using DungeonLabMaster.MovableEntities;

namespace DungeonLabMaster.Items;

public class DecoratorUnlucky: ItemDecorator
{
    protected override IPlayerEnt.PlayerStatsT getModifierStats() 
    {
        return new IPlayerEnt.PlayerStatsT { Luck = -5 };
    }

    public DecoratorUnlucky(IItem item) : base(item)
    {
        ;
    }
    protected override string getModifierName() => "Unlucky";
}