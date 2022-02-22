using System;
using System.Collections.Generic;

namespace WanderersDiary.CharacterManagement.Models
{
    public class Character : IEquatable<Character>
    {
        public string Name { get; set; }

        public HitPoints HitPoints { get; set; } = new HitPoints();

        public List<HitDice> HitDices { get; set; } = new List<HitDice>();

        public Appearance Appearance { get; set; } = new Appearance();

        public Personality Personality { get; set; } = new Personality();

        public Attributes Attributes { get; set; } = new Attributes();

        public List<Feat> Feats { get; set; } = new List<Feat>();

        public List<SkillProficiency> Skills { get; set; } = new List<SkillProficiency>();

        public Queue<SkillsToChoose> SkillsToChoose { get; set; } = new Queue<SkillsToChoose>();

        public ArmouryProficiencies ArmouryProficiencies { get; set; } = new ArmouryProficiencies();

        public List<CommonProficiency> Tools { get; set; } = new List<CommonProficiency>();

        public List<CommonProficiency> Languages { get; set; } = new List<CommonProficiency>();

        public List<CommonProficiency> OtherProficiencies { get; set; } = new List<CommonProficiency>();

        /// <summary>
        /// Gained  from race and modified later
        /// </summary>
        public Speed Speed { get; set; } = new Speed();

        /// <summary>
        /// Gained  from race and modified later
        /// </summary>
        public Senses Senses { get; set; } = new Senses();

        public Background Background { get; set; } = new Background();

        public CharacterRace Race { get; set; }

        public List<CharacterClass> Classes { get; set; } = new List<CharacterClass>();

        public int Experience { get; set; }

        public List<SpellSlot> SpellSlots { get; set; } = new List<SpellSlot>();

        public List<Spell> PreparedSpells { get; set; } = new List<Spell>();

        public int MaxPreparedSpellsCount { get; set; }

        /// <summary>
        /// By default have main conatiner named as "Other"
        /// </summary>
        public List<InventoryContainer> Inventory { get; set; } = new List<InventoryContainer>();

        public int SuccessfullDeathSaves { get; set; }
        
        public int FailedDeathSaves { get; set; }

        //Conditions

        //Equipped weapons

        //Equipped armor

        //Magic items and eqipped magic items

        //Immunity, Resistance & Vulnerability

        //Currency

        //Referenced Monster (companion or wild shape)

        public bool Equals(Character other)
        {
            return CharacterManagement.Utility.IsEqual(this, other);
        }
    }
}
