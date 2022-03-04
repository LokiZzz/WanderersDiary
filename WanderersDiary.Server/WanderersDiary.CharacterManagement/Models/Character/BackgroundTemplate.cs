using System.Collections.Generic;
using WanderersDiary.CharacterManagement.Models.Enums;

namespace WanderersDiary.CharacterManagement.Models
{
    public class BackgroundTemplate
    {
        public string Title { get; set; }

        public string FactionsAndTitles { get; set; }

        public string BackgroundFeatures { get; set; }

        public string Description { get; set; }

        public List<ESkill> AvailiableSkills { get; set; }
    }
}
