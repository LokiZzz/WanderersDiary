using WanderersDiary.Shared.Game;

namespace WanderersDiary.CharacterManagement.Models
{
    public class HitDice
    {
        public int Current { get; set; }

        public int Max { get; set; }

        public EDice Type { get; set; }
    }
}
