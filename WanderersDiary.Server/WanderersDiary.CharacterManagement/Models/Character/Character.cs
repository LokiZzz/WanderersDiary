using System;
using System.Collections.Generic;
using WanderersDiary.CharacterManagement.Models;

namespace WanderersDiary.CharacterManagement.Models
{
    public class Character : IEquatable<Character>
    {
        public string Name { get; set; }

        public int CurrentHitPoints { get; set; }

        public int MaxHitPoints { get; set; }

        public List<HitDice> HitDices { get; set; } = new List<HitDice>();

        public Appearance Appearance { get; set; }

        public Personality Personality { get; set; }

        public Attributes Attributes { get; set; }

        public List<Feat> Feats { get; set; }

        public List<SkillProficiency> Skills { get; set; } = new List<SkillProficiency>();

        public Queue<SkillsToChoose> SkillsToChoose { get; set; } = new Queue<SkillsToChoose>();

        public ArmouryProficiencies ArmouryProficiencies { get; set; }

        public List<CommonProficiency> Tools { get; set; } = new List<CommonProficiency>();

        public List<CommonProficiency> Languages { get; set; } = new List<CommonProficiency>();

        public List<CommonProficiency> OtherProficiencies { get; set; } = new List<CommonProficiency>();

        /// <summary>
        /// Gained  from race and modified later
        /// </summary>
        public Speed Speed { get; set; }

        /// <summary>
        /// Gained  from race and modified later
        /// </summary>
        public Senses Senses { get; set; }

        public Background Background { get; set; }

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
