using System;
using System.Collections.Generic;
using System.Text;

namespace WanderersDiary.CharacterManagement.Models
{
    public class CharacterInventory
    {
        public List<InventoryContainer> Inventory { get; set; } = new List<InventoryContainer>();

        public List<Weapon> Weapons { get; set; } = new List<Weapon>();

        /// <summary>
        /// Armor, including shields and other...
        /// </summary>
        public List<Armor> Armor { get; set; } = new List<Armor>();

        public List<Currency> Currency { get; set; } = new List<Currency>();
    }
}
