using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanderersDiary.Entities.Models
{
    public class SpellSlot : EntityBase
    {
        public int Level { get; set; }

        public int Current { get; set; }

        public int Max { get; set; }
    }
}
