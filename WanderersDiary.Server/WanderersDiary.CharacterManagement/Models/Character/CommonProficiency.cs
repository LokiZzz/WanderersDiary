using WanderersDiary.Shared.Game;

namespace WanderersDiary.CharacterManagement.Models
{
    public class CommonProficiency
    {
        /// <summary>
        /// Tool, language, vehicle, etc.
        /// </summary>
        public string Competence { get; set; }

        public EProficiency Proficiency { get; set; }
    }
}
