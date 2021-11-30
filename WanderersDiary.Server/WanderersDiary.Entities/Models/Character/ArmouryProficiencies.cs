using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanderersDiary.Entities.Models.Character
{
    public class ArmouryProficiencies : EntityBase
    {
        public bool LightArmor { get; set; }
        public bool MediumArmor { get; set; }
        public bool HeavyArmor { get; set; }
        public bool Shields { get; set; }

        public bool SimpleWeapons { get; set; }
        public bool MartialWeapons { get; set; }
        public bool Firearms { get; set; }

        public ICollection<CommonProficiency> Specific { get; set; }
    }
}
