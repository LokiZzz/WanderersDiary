using System.Collections.Generic;

namespace WanderersDiary.CharacterManagement.Models
{
    public class ArmouryProficiencies
    {
        public bool LightArmor { get; set; }
        public bool MediumArmor { get; set; }
        public bool HeavyArmor { get; set; }
        public bool Shields { get; set; }

        public bool SimpleWeapons { get; set; }
        public bool MartialWeapons { get; set; }
        public bool Firearms { get; set; }

        public List<Weapon> Specific { get; set; }
    }
}
