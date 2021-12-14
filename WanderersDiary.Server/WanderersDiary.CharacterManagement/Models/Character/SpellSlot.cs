namespace WanderersDiary.CharacterManagement.Models
{
    public class SpellSlot
    {
        public SpellSlot(int level, int count)
        {
            Level = level;
            Max = count;
        }

        public int Level { get; set; }

        public int Spent { get; set; }

        public int Max { get; set; }
    }
}
