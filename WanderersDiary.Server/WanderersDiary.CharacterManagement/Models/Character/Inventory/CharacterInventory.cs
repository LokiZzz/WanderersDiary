using System;
using System.Collections.Generic;
using System.Text;

namespace WanderersDiary.CharacterManagement.Models
{
    public class CharacterInventory
    {
        public List<Equipment> Content { get; set; } = new List<Equipment>();

        public List<Weapon> EquipedWeapons { get; set; } = new List<Weapon>();

        /// <summary>
        /// Armor, including shields and other...
        /// </summary>
        public List<Armor> EquipedArmor { get; set; } = new List<Armor>();

        public List<Currency> Currency { get; set; } = new List<Currency>();

        public List<EquipmentToChoose> EquipmentToChoose { get; set; } = new List<EquipmentToChoose>();
    }
}
