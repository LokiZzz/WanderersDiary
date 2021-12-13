using System;
using System.Collections.Generic;
using System.Text;
using WanderersDiary.CharacterManagement.Models;

namespace WanderersDiary.CharacterManagement.Classes
{
    public class ClassLevelFeatures
    {
        public int Level { get; set; }

        public List<Feature> Features { get; set; }
    }
}
