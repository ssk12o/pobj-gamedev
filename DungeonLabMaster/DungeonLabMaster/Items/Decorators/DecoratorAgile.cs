using DungeonLabMaster.MovableEntities;

namespace DungeonLabMaster.Items;

public class DecoratorAgile: ItemDecorator
{
    public DecoratorAgile(IItem item) : base(item)
    {
        ;
    }

    protected override IAliveEntity.PlayerStatsT getModifierStats()
    {
        return new IAliveEntity.PlayerStatsT {Agility = 10};

    }

    protected override string getModifierName() => "Agile";
    public override int GetDamage(IAliveEntity.PlayerStatsT playerStats)
    {
        return base.GetDamage(playerStats) + 3;
    }

    protected override int GetDefenseBonus() => -1;
}