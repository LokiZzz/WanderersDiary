using WanderersDiary.CharacterManagement.Models.Utility;

namespace WanderersDiary.CharacterManagement.Models
{ 
    public class InventoryItem
    {
        public LocalizedString Name { get; set; }

        public decimal? Price { get; set; }

        public decimal? Weight { get; set; }

        public bool IsMagicalItem { get; set; }
    }
}
