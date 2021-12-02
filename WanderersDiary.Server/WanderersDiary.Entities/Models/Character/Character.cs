using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WanderersDiary.Entities.Models;
using WanderersDiary.Entities.Models.Character;
using WanderersDiary.Entities.Models.Spell;

namespace WanderersDiary.Entities.Character
{
    public class Character : EntityBase
    {
        public string Name { get; set; }

        public Appearance Appearance { get; set; }

        public Personality Personality { get; set; }

        public Attributes Attributes { get; set; }

        public ICollection<SkillProficiency> Skills { get; set; }

        public ArmouryProficiencies ArmouryProficiencies { get; set; }

        public ICollection<CommonProficiency> Tools { get; set; }

        public ICollection<CommonProficiency> Languages { get; set; }

        public ICollection<CommonProficiency> OtherProficiencies { get; set; }

        /// <summary>
        /// Gained  from race and modified later
        /// </summary>
        public Speed Speed { get; set; }

        /// <summary>
        /// Gained  from race and modified later
        /// </summary>
        public Senses Senses { get; set; }

        public Background Background { get; set; }

        public Race Race { get; set; }

        public ICollection<CharacterClass> Classes { get; set; }

        public int Experience { get; set; }

        public ICollection<SpellSlot> SpellSlots { get; set; }

        public ICollection<Spell> PreparedSpells { get; set; }

        /// <summary>
        /// By default have main conatiner named as "Other"
        /// </summary>
        public ICollection<InventoryContainer> Inventory { get; set; }

        public int SuccessfullDeathSaves { get; set; }
        
        public int FailedDeathSaves { get; set; }

        //Conditions

        //Equipped weapons

        //Equipped armor

        //Magic items and eqipped magic items

        //Equipped Immunity, Resistance & Vulnerability

        //Currency

        //Referenced Monster (companion or wild shape)
    }
}
