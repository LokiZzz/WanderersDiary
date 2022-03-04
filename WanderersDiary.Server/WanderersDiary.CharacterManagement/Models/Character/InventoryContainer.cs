using System.Collections.Generic;
using WanderersDiary.CharacterManagement.Models.Utility;

namespace WanderersDiary.CharacterManagement.Models
{
    public class InventoryContainer
    {
        public LocalizedString Name { get; set; }

        public List<InventoryContainer> Containers { get; set; }

        public List<InventoryItem> Items { get; set; }
    }
}
