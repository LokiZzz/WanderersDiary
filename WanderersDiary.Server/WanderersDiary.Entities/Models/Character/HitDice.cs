using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanderersDiary.Shared.Game;

namespace WanderersDiary.Entities.Models
{
    public class HitDice : EntityBase
    {
        public int Current { get; set; }

        public int Max { get; set; }

        public EDice Type { get; set; }
    }
}
