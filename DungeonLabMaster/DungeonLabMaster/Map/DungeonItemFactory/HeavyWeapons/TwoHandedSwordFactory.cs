using DungeonLabMaster.Items;

namespace DungeonLabMaster.Map.FactoryDep;

public class TwoHandedSwordFactory: IFactoryDep
{
    private int _minAttack = 20;
    private int _maxAttack = 30;
    private int _minDefense = 12;
    private int _maxDefense = 20;

    public IItem Create()
    {
        int index = Random.Shared.Next(TwoHandedSwordsNames.Length);
        return new TwoHandedSword(Random.Shared.Next(_minAttack, _maxAttack + 1), Random.Shared.Next(_minDefense, _maxDefense + 1),
            TwoHandedSwordsNames[index], TwoHandedSwordsDescriptions[index]);
    }
    // ai generated
    public static string[] TwoHandedSwordsNames = new string[]
    {
        "Greatsword",
        "Claymore",
        "Zweihander",
        "Bastard Sword",
        "Flamberge",
        "Montante",
        "Iron Greatblade",
        "Steel Greatsword",
        "Obsidian Cleaver",
        "Dragon Slayer",
        "Demon Bane",
        "King's Greatsword",
        "Executioner's Blade",
        "Colossal Sword",
        "Moonlight Greatsword",
        "Sunlight Greatblade",
        "Storm Bringer",
        "Earth Shaker",
        "Frost Greatsword",
        "Flame Greatblade",
        "Void Edge",
        "Holy Greatsword",
        "Dark Greatblade",
        "Ancestral Claymore",
        "Ruin Greatsword",
        "Bloodhound Greatsword",
        "Grafted Blade",
        "Magic Greatsword",
        "Ancient Zweihander",
        "Worldbreaker"
    };
    // ai generated
    public static string[] TwoHandedSwordsDescriptions = new string[]
    {
        "A massive blade requiring both hands to wield effectively.",
        "A long Scottish sword designed for cutting through armor.",
        "A huge Germanic sword used to break pike formations.",
        "A versatile blade that can be used with one or two hands.",
        "A wavy blade that causes terrible wounds upon impact.",
        "A long thrusting sword used for guarding narrow passages.",
        "A heavy slab of iron meant for crushing rather than cutting.",
        "A refined large sword balanced for sustained combat.",
        "A brittle but razor-sharp giant blade made of volcanic glass.",
        "Specifically forged to hunt down large draconic creatures.",
        "Enchanted to deal extra damage to demonic entities.",
        "A regal weapon symbolizing the king's absolute power.",
        "A broad, heavy blade designed for delivering final blows.",
        "An unwieldy weapon of immense size and destructive power.",
        "Glowing with cold lunar energy, heavy yet mystical.",
        "Radiating intense heat and blinding light.",
        "Crackles with lightning that jumps between enemies.",
        "So heavy it causes tremors when slammed into the ground.",
        "Encased in perpetual ice that freezes the blood of foes.",
        "Wreathed in smoke and fire, burning everything it touches.",
        "A blade that seems to cut through space itself.",
        "Blessed by high priests to purge corruption.",
        "Feeds on the life force of those it strikes.",
        "Passed down through generations, worn but reliable.",
        "A broken relic restored, carrying the weight of history.",
        "A curved greatsword favored by hunters of beasts.",
        "A grotesque combination of multiple blades fused together.",
        "Humming with arcane energy, dangerous to the untrained.",
        "A relic from a forgotten war, incredibly durable.",
        "Said to be capable of splitting mountains in two."
    };
}