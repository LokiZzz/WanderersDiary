using System;
using System.Collections.Generic;
using System.Text;

namespace WanderersDiary.CharacterManagement.Models
{
    public class EquipmentToChoose
    {
        public EquipmentToChoose(params Equipment[] items)
        {
            Option = new List<Equipment>();

            foreach (Equipment item in items)
            {
                Option.Add(item);
            }
        }

        public EquipmentToChoose(List<EquipmentToChoose> group)
        {
            GroupToChooseFrom = group;
        }

        public List<Equipment> Option { get; set; }

        public List<EquipmentToChoose> GroupToChooseFrom { get; set; }
    }
}
