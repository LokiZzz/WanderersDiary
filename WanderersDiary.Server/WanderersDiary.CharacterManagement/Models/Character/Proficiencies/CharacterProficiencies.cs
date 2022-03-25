using System;
using System.Collections.Generic;
using System.Text;
using WanderersDiary.CharacterManagement.Models.Utility;

namespace WanderersDiary.CharacterManagement.Models
{
    public class CharacterProficiencies
    {
        public ArmouryProficiencies Armoury { get; set; } = new ArmouryProficiencies();

        public List<Equipment> Tools { get; set; } = new List<Equipment>();

        public List<LocalizedString> Languages { get; set; } = new List<LocalizedString>();

        public List<CommonProficiency> Other { get; set; } = new List<CommonProficiency>();
    }
}
