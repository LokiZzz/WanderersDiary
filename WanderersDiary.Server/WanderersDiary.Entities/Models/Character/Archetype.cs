using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanderersDiary.Contracts.Game;
using WanderersDiary.Entities.Character;

namespace WanderersDiary.Entities.Models.Character
{
    public class Archetype : EntityBase
    {
        public string Name_EN { get; set; }

        public string Name_RU { get; set; }

        public string Description_EN { get; set; }

        public string Description_RU { get; set; }

        public Class Class { get; set; }

        public ICollection<Feature> Features { get; set; }
    }
}
