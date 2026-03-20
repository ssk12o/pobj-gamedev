using System.Security.Cryptography;
using DungeonLabMaster.Items;
using DungeonLabMaster.Items.Weapons;
using Microsoft.VisualBasic;

namespace DungeonLabMaster.Map.FactoryDep;

public class OneHandedSwordFactory
{
    private int minAttack = 12;
    private int maxAttack = 30;
    private int minDefense = 12;
    private int maxDefense = 20;

    public IItem Create()
    {
        int index = Random.Shared.Next(OneHandedSwordsNames.Length);
        return new OneHandedSword(Random.Shared.Next(minAttack, maxAttack+1), Random.Shared.Next(minDefense, maxDefense),
            OneHandedSwordsNames[index], OneHandedSwordsDescriptions[index]);
    }
    // ai generated
    public static string[] OneHandedSwordsNames = new string[]
    {
        "Iron Longsword",
        "Steel Shortsword",
        "Royal Rapier",
        "Knight's Broadsword",
        "Desert Scimitar",
        "Paladin's Saber",
        "Obsidian Edge",
        "Crystal Cutter",
        "Dragon Tooth",
        "Shadowfang",
        "Sunblade",
        "Moonblade",
        "Wind Cutter",
        "Thunder Edge",
        "Frost Bite",
        "Flame Tongue",
        "Durendal",
        "Joyeuse",
        "Curtana",
        "Almace",
        "Hauteclere",
        "Fragarach",
        "Caladbolg",
        "Assassin's Blade",
        "Mercenary's Cutlass",
        "Guardian's Edge",
        "Venom Sting",
        "Holy Avenger",
        "Blacksteel Katana",
        "Ancient Gladius"
    };
    // ai generated
    public static string[] OneHandedSwordsDescriptions = new string[]
    {
        "A sturdy weapon forged from common iron, reliable but heavy.",
        "A balanced blade made of refined steel, ideal for quick thrusts.",
        "An elegant fencing sword adorned with gold, fit for nobility.",
        "A wide-bladed weapon used by seasoned knights in battle.",
        "A curved blade designed for slashing in hot climates.",
        "A blessed curved sword that glows faintly in the presence of evil.",
        "Crafted from volcanic glass, razor-sharp but brittle.",
        "A translucent blade that refracts light into dazzling patterns.",
        "Forged from the actual tooth of a wyrm, incredibly hard.",
        "A dark blade that seems to absorb light around it.",
        "Radiates warmth and light, effective against undead.",
        "A silvery blade that gleams brighter under the night sky.",
        "So light it feels weightless, allowing for rapid strikes.",
        "Crackles with static electricity when swung.",
        "Always cold to the touch, leaving ice on wounded foes.",
        "The blade appears to be wreathed in eternal fire.",
        "A legendary blade said to be indestructible.",
        "The famed sword of kings, imbued with authority.",
        "The sword of mercy, with a blunt tip to spare lives.",
        "A holy relic known for its piercing power.",
        "A shining weapon said to never dull in combat.",
        "The Answerer, known for striking true against any defense.",
        "A legendary sword capable of slicing hilltops.",
        "A concealed blade designed for silent eliminations.",
        "A rough weapon favored by sellswords and sailors.",
        "Enchanted to protect the wielder from critical blows.",
        "Coated in a potent poison that drains vitality.",
        "A divine weapon crafted to smite demons.",
        "A folded steel blade from the east, dark and deadly.",
        "A Roman-style short sword recovered from ruins."
    };
}
