namespace WanderersDiary.CharacterManagement.Models
{
    public class Spell
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
