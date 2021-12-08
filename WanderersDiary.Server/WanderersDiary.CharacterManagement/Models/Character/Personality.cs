using WanderersDiary.Shared.Game;

namespace WanderersDiary.CharacterManagement.Models
{
    public class Personality
    {
        public EAlignment Alignment { get; set; }

        public string Traits { get; set; }
        
        public string Ideals { get; set; }
        
        public string Bonds { get; set; }
        
        public string Flaws { get; set; }

        public string OtherInfo { get; set; }
    }
}
