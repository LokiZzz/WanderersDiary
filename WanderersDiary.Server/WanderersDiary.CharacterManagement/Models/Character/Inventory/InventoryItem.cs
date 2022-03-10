using WanderersDiary.CharacterManagement.Models.Utility;

namespace WanderersDiary.CharacterManagement.Models
{ 
    public class InventoryItem
    {
        public LocalizedString Name { get; set; }

        public int? Price { get; set; }

        public int Weight { get; set; }

        public bool IsMagicalItem { get; set; }
    }
}
