using DungeonLabMaster.MovableEntities;

namespace DungeonLabMaster.Items;

public class DecoratorMad :ItemDecorator
{
    public DecoratorMad(IItem item) : base(item)
    {
        ;
    }

    protected override IAliveEntity.PlayerStatsT getModifierStats()
    {
        return new IAliveEntity.PlayerStatsT {Aggresion = 12};

    }

    protected override string getModifierName() => "Mad";
    public override int GetDamage(IAliveEntity.PlayerStatsT playerStats)
    {
        return base.GetDamage(playerStats) + 4;
    }

    protected override int GetDefenseBonus() => -1;
}