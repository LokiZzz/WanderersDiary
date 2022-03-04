using WanderersDiary.CharacterManagement.Models.Enums;
using WanderersDiary.CharacterManagement.Models.Utility;

namespace WanderersDiary.CharacterManagement.Models
{
    public class Feat
    {
        public int Index { get; set; }

        public LocalizedString Description { get; set; }

        public ESource Source { get; set; }

        public int HitPointsFactor { get; set; }

        //Maybe other factors: AC, Speed
    }
}
