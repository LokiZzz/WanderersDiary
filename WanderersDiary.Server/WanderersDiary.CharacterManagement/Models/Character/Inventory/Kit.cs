using System;
using System.Collections.Generic;
using System.Text;
using WanderersDiary.CharacterManagement.Models.Utility;

namespace WanderersDiary.CharacterManagement.Models
{
    public class Pack
    {
        public LocalizedString Name { get; set; }

        public decimal Price { get; set; }

        public List<Equipment> Items { get; set; }
    }
}
