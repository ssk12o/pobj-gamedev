using DungeonLabMaster.MovableEntities;

namespace DungeonLabMaster.Items;

public class DecoratorUnlucky: ItemDecorator
{
    protected override IAliveEntity.PlayerStatsT getModifierStats() 
    {
        return new IAliveEntity.PlayerStatsT { Luck = -5 };
    }

    public DecoratorUnlucky(IItem item) : base(item)
    {
        ;
    }
    protected override string getModifierName() => "Unlucky";
}