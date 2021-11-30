using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanderersDiary.Contracts.Game;

namespace WanderersDiary.Entities.Models.Character
{
    public class BackgroundTemplate : EntityBase
    {
        public string Title { get; set; }

        public string FactionsAndTitles { get; set; }

        public string BackgroundFeatures { get; set; }

        public string Description { get; set; }

        public ICollection<ESkill> AvailiableSkills { get; set; }
    }
}
