using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanderersDiary.Entities.Models.Character
{
    public class Senses : EntityBase
    {
        public int Darkvision { get; set; }

        public int Blindsight { get; set; }

        public int Truesight { get; set; }

        public int Tremorsense { get; set; }
    }
}
