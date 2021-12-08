using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanderersDiary.Shared;

namespace WanderersDiary.Entities.Models
{
    public class Appearance : EntityBase
    {
        public EGender Gender { get; set; }

        public int Age { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        public string Description { get; set; }
    }
}
