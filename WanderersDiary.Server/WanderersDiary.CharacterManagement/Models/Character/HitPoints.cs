using System;
using System.Collections.Generic;
using System.Text;

namespace WanderersDiary.CharacterManagement.Models
{
    public class HitPoints
    {
        public int Current { get; set; }

        public int Maximum { get; set; }

        public int Temporary { get; set; }

        public int TemporaryModifier { get; set; }
    }
}
