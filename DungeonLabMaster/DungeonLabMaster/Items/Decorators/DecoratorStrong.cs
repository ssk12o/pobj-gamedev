using DungeonLabMaster.MovableEntities;

namespace DungeonLabMaster.Items;

public class DecoratorStrong: ItemDecorator
{
    public DecoratorStrong(IItem item) : base(item)
    {
        ;
    }

    protected override IAliveEntity.PlayerStatsT getModifierStats()
    {
        return new  IAliveEntity.PlayerStatsT { };
    }

    protected override string getModifierName() => "Strong";
    public override int GetDamage(IAliveEntity.PlayerStatsT playerStats)
    {
        return base.GetDamage(playerStats) + 5;
    }

    protected override int GetDefenseBonus() => 10;
}