using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanderersDiary.TestConsole
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class En
    {
        public string title { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string typeAdditions { get; set; }
        public int rarity { get; set; }
        public string text { get; set; }
        public string coast { get; set; }
        public string source { get; set; }
        public string img { get; set; }
        public string ac { get; set; }
        public bool stealthDis { get; set; }
        public string weight { get; set; }
        public string damageVal { get; set; }
        public string damageType { get; set; }
        public List<string> props { get; set; }
    }

    public class Ru
    {
        public string title { get; set; }
        public string gender { get; set; }
        public string he { get; set; }
        public string she { get; set; }
        public string it { get; set; }
        public string name { get; set; }
        public string text { get; set; }
        public string nic { get; set; }
    }

    public class Text
    {
        public En en { get; set; }
        public Ru ru { get; set; }
    }

    public class PHB
    {
        public Text text { get; set; }
    }

    public class SourceList
    {
        public PHB PHB { get; set; }
    }

    public class Armor
    {
        public Text text { get; set; }
        public List<string> subTypes { get; set; }
        public string img { get; set; }
    }

    public class Weapon
    {
        public Text text { get; set; }
        public List<string> subTypes { get; set; }
        public string img { get; set; }
    }

    public class Ammunition
    {
        public Text text { get; set; }
        public string img { get; set; }
    }

    public class Consumables
    {
        public Text text { get; set; }
        public string img { get; set; }
    }

    public class Kit
    {
        public Text text { get; set; }
        public string img { get; set; }
    }

    public class Tool
    {
        public Text text { get; set; }
        public string img { get; set; }
    }

    public class Gear
    {
        public Text text { get; set; }
        public string img { get; set; }
    }

    public class Container
    {
        public Text text { get; set; }
        public string img { get; set; }
    }

    public class ArcaneFocus
    {
        public Text text { get; set; }
        public string img { get; set; }
    }

    public class DruidicFocus
    {
        public Text text { get; set; }
        public string img { get; set; }
    }

    public class HollySimbol
    {
        public Text text { get; set; }
        public string img { get; set; }
    }

    public class Clothes
    {
        public Text text { get; set; }
        public string img { get; set; }
    }

    public class Camp
    {
        public Text text { get; set; }
        public string img { get; set; }
    }

    public class TypeList
    {
        public Armor armor { get; set; }
        public Weapon weapon { get; set; }
        public Ammunition ammunition { get; set; }
        public Consumables consumables { get; set; }
        public Kit kit { get; set; }
        public Tool tool { get; set; }
        public Gear gear { get; set; }
        public Container container { get; set; }

        [JsonProperty("arcane focus")]
        public ArcaneFocus ArcaneFocus { get; set; }

        [JsonProperty("druidic focus")]
        public DruidicFocus DruidicFocus { get; set; }

        [JsonProperty("holly simbol")]
        public HollySimbol HollySimbol { get; set; }
        public Clothes clothes { get; set; }
        public Camp camp { get; set; }
    }

    public class Light
    {
        public Text text { get; set; }
    }

    public class Medium
    {
        public Text text { get; set; }
    }

    public class Heavy
    {
        public Text text { get; set; }
    }

    public class Simple
    {
        public Text text { get; set; }
    }

    public class Shield
    {
        public Text text { get; set; }
    }

    public class Melee
    {
        public Text text { get; set; }
    }

    public class Ranged
    {
        public Text text { get; set; }
    }

    public class Martial
    {
        public Text text { get; set; }
    }

    public class TypeAddList
    {
        public Light light { get; set; }
        public Medium medium { get; set; }
        public Heavy heavy { get; set; }
        public Simple simple { get; set; }
        public Shield shield { get; set; }
        public Melee melee { get; set; }
        public Ranged ranged { get; set; }
        public Martial martial { get; set; }
    }

    public class Piercing
    {
        public Text text { get; set; }
    }

    public class Bludgeoning
    {
        public Text text { get; set; }
    }

    public class Slashing
    {
        public Text text { get; set; }
    }

    public class TypeDamagemList
    {
        public Piercing piercing { get; set; }
        public Bludgeoning bludgeoning { get; set; }
        public Slashing slashing { get; set; }
    }

    public class DexModifier
    {
        public Text text { get; set; }
    }

    public class Max
    {
        public Text text { get; set; }
    }

    public class AcList
    {
        [JsonProperty("dex modifier")]
        public DexModifier DexModifier { get; set; }
        public Max max { get; set; }
    }

    public class Versatile
    {
        public Text text { get; set; }
    }

    public class Thrown
    {
        public Text text { get; set; }
    }

    public class Range
    {
        public Text text { get; set; }
    }

    public class TwoHanded
    {
        public Text text { get; set; }
    }

    public class Finesse
    {
        public Text text { get; set; }
    }

    public class Reach
    {
        public Text text { get; set; }
    }

    public class Loading
    {
        public Text text { get; set; }
    }

    public class Special
    {
        public Text text { get; set; }
    }

    public class WeaponPropsList
    {
        public Light light { get; set; }
        public Heavy heavy { get; set; }
        public Versatile versatile { get; set; }
        public Thrown thrown { get; set; }
        public Range range { get; set; }

        [JsonProperty("two-handed")]
        public TwoHanded TwoHanded { get; set; }
        public Finesse finesse { get; set; }
        public Reach reach { get; set; }
        public Ammunition ammunition { get; set; }
        public Loading loading { get; set; }
        public Special special { get; set; }
    }

    public class ItemsList
    {
        public En en { get; set; }
        public Ru ru { get; set; }
    }

    public class Root
    {
        public SourceList sourceList { get; set; }
        public TypeList typeList { get; set; }
        public TypeAddList typeAddList { get; set; }
        public TypeDamagemList typeDamagemList { get; set; }
        public AcList acList { get; set; }
        public WeaponPropsList weaponPropsList { get; set; }
        public List<ItemsList> itemsList { get; set; }
    }
}
