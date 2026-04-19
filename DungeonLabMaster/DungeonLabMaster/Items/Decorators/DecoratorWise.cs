using DungeonLabMaster.MovableEntities;

namespace DungeonLabMaster.Items;

public class DecoratorWise: ItemDecorator
{
    public DecoratorWise(IItem item) : base(item)
    {
        ;
    }

    protected override IAliveEntity.PlayerStatsT getModifierStats()
    {
        return new IAliveEntity.PlayerStatsT { Intelligence = 12 };

    }
    protected override string getModifierName() => "Wise";
}