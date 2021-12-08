using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanderersDiary.Entities.Models
{
    public class Speed : EntityBase
    {
        public int Walk { get; set; }

        public int Swim { get; set; }

        public int Fly { get; set; }

        public int Climb { get; set; }

        public int Burrow { get; set; }
    }
}
