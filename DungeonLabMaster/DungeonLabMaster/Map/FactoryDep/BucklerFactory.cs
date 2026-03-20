using DungeonLabMaster.Items;

namespace DungeonLabMaster.Map.FactoryDep;

public class BucklerFactory
{
    private int minAttack = 12;
    private int maxAttack = 30;
    private int minDefense = 12;
    private int maxDefense = 20;

    public IItem Create()
    {
        int index = Random.Shared.Next(BucklerNames.Length);
        return new TwoHandedSword(Random.Shared.Next(minAttack, maxAttack+1), Random.Shared.Next(minDefense,maxDefense),
            BucklerNames[index], BucklerDescriptions[index]);
    }
    
    public static string[] BucklerNames = new string[]
    {
        "Iron Buckler",
        "Steel Buckler",
        "Wooden Buckler",
        "Leather Buckler",
        "Bronze Buckler",
        "Silver Buckler",
        "Golden Buckler",
        "Mithril Buckler",
        "Obsidian Buckler",
        "Crystal Buckler",
        "Spiked Buckler",
        "Parrying Shield",
        "Duelist's Buckler",
        "Rogue's Guard",
        "Squire's Buckler",
        "Paladin's Buckler",
        "Shadow Buckler",
        "Light Buckler",
        "Fire Ward",
        "Frost Guard",
        "Thunder Shield",
        "Wind Buckler",
        "Earth Buckler",
        "Void Buckler",
        "Holy Buckler",
        "Dark Buckler",
        "Ancient Buckler",
        "Ruined Buckler",
        "Royal Buckler",
        "Dragon Buckler"
    };

    public static string[] BucklerDescriptions = new string[]
    {
        "A common iron shield, basic but reliable for deflection.",
        "A refined steel buckler, balanced for quick parries.",
        "Made of light wood, fast but offers minimal protection.",
        "Bound in hardened leather, silent and lightweight.",
        "An old bronze shield, heavy but durable against rust.",
        "Crafted from pure silver, effective against lycanthropes.",
        "Gilded with gold, ornate but soft against heavy blows.",
        "Forged from magical metal, incredibly light yet strong.",
        "Made of volcanic glass, sharp edges deter grappling.",
        "A translucent shield that refracts magical attacks.",
        "Fitted with protruding spikes to punish close attackers.",
        "Designed specifically for timing and deflecting thrusts.",
        "A balanced shield favored for one-on-one duels.",
        "Small and quiet, perfect for stealthy defenders.",
        "Standard issue for squires learning the art of defense.",
        "A blessed small shield that glows in holy presence.",
        "Absorbs light around it, making the wielder harder to hit.",
        "Glows brightly, illuminating dark dungeons.",
        "Enchanted to resist heat and flame damage.",
        "Encased in perpetual ice, chilling those who strike it.",
        "Conducts lightning, shocking attackers on block.",
        "So light it feels like air, boosting movement speed.",
        "Heavy and grounded, resistant to knockback.",
        "Distorts reality around it, bending incoming projectiles.",
        "Embeds a holy symbol, purging evil on contact.",
        "Feeds on the life force of those who strike it.",
        "Recovered from ancient ruins, still remarkably intact.",
        "Broken and battered, but still functional in a pinch.",
        "Fit for a prince, adorned with gems and crests.",
        "Crafted from dragon scales, resistant to breath weapons."
    };
}