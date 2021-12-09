using System.Collections.Generic;

namespace WanderersDiary.CharacterManagement.Models
{
    public class InventoryContainer
    {
        public string Name { get; set; }

        public List<InventoryItem> Items { get; set; }
    }
}
