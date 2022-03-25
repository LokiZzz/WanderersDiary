using WanderersDiary.CharacterManagement.Models.Enums;
using WanderersDiary.CharacterManagement.Models.Utility;

namespace WanderersDiary.CharacterManagement.Models
{
    public class CommonProficiency
    {
        /// <summary>
        /// Tool, language, vehicle, etc.
        /// </summary>
        public LocalizedString Competence { get; set; }

        public EProficiency Proficiency { get; set; }
    }
}
