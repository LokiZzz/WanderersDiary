using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanderersDiary.Entities.Models
{
    public class SpellDuration : EntityBase
    {
        public string Duration_EN { get; set; }

        public string Duration_RU { get; set; }

        public bool Concentration { get; set; }
    }
}
