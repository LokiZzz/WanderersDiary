using System;
using System.Collections.Generic;
using System.Text;
using WanderersDiary.CharacterManagement.Models.Utility;

namespace WanderersDiary.CharacterManagement.Models
{
    public class Pack : Equipment
    {
        public LocalizedString PackName { get; set; }

        public decimal PackPrice { get; set; }
    }
}
