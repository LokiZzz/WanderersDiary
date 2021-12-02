using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WanderersDiary.Contracts.Game;
using WanderersDiary.Entities.Character;
using WanderersDiary.Entities.Models.Character;

namespace WanderersDiary.API.Services.Seed
{
    public static class ClassesSeed
    {
        public static List<Class> Classes => new List<Class>
        {
            new Class
            {
                Name_RU = "Бард", 
                Name_EN = "Bard",
                Description_RU = "Неважно, кем является бард: учёным, скальдом или проходимцем; он плетёт магию из слов и музыки, вдохновляя союзников, деморализуя противников, манипулируя сознанием, создавая иллюзии, и даже исцеляя раны.",
                Description_EN = "Whether scholar, skald, or scoundrel, a bard weaves magic through words and music to inspire allies, demoralize foes, manipulate minds, create illusions, and even heal wounds. The bard is a master of song, speech, and the magic they contain.",
                HitDice = EDice.D8,
                

                //Специальное оружие и броня, а так же инструменты требуют нормального описания оружия и брони!!!
                ArmouryProficiencies = new ArmouryProficiencies { LightArmor = true, SimpleWeapons = true, Specific = new List<CommonProficiency> { new CommonProficiency {  } } },
                Tools = new List<CommonProficiency> { },
                

                AvailiableSkillNumber = 3,
                Skills = new List<ESkill> { ESkill.Athletics, ESkill.Acrobatics, ESkill.SleightOfHand, ESkill.Stealth, ESkill.Arcana, ESkill.History, ESkill.Investigation, ESkill.Nature, ESkill.Religion, 
                    ESkill.AnimalHandling, ESkill.Insight, ESkill.Medicine, ESkill.Perception, ESkill.Survival, ESkill.Deception, ESkill.Intimidation, ESkill.Performance, ESkill.Persuasion },
                
                DexteritySave = true, CharismaSave = true,


                //В случае с зависимыми величинами типа использований, привязанных к уровню или характеристике, нужно проставлять MaxUses с клиента.
                Features = new List<Feature>
                {
                    new Feature
                    {
                        
                    }
                }
            }
        };
    }
}
