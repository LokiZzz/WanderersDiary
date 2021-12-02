using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanderersDiary.Entities.Models.Spell
{
    public class Spell : EntityBase
    {
        public string Name_EN { get; set; }

        public string Name_RU { get; set; }

        public int Level { get; set; }

        public SchoolOfMagic SchoolOfMagic { get; set; }

        public string Description_EN { get; set; }

        public string Description_RU { get; set; }

        public CastTime CastTime { get; set; }

        public CastRange CastRange { get; set; }

        public SpellDuration SpellDuration { get; set; }

        public bool IsRitual { get; set; }

        public bool Verbal { get; set; }

        public bool Somatic { get; set; }

        public bool Material { get; set; }
    }
}
