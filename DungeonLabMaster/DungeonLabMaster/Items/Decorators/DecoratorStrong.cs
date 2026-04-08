using DungeonLabMaster.MovableEntities;

namespace DungeonLabMaster.Items;

public class DecoratorStrong: ItemDecorator
{
    public DecoratorStrong(IItem item) : base(item)
    {
        ;
    }

    protected override IPlayerEnt.PlayerStatsT getModifierStats()
    {
        return new  IPlayerEnt.PlayerStatsT { };
    }

    protected override string getModifierName() => "Strong";
    public override int GetDamage(IPlayerEnt.PlayerStatsT playerStats)
    {
        return base.GetDamage(playerStats) + 5;
    }
}