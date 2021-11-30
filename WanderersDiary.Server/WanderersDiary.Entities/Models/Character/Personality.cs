using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanderersDiary.Contracts.Game;

namespace WanderersDiary.Entities.Models.Character
{
    public class Personality : EntityBase
    {
        public EAlignment Alignment { get; set; }

        public string Traits { get; set; }
        
        public string Ideals { get; set; }
        
        public string Bonds { get; set; }
        
        public string Flaws { get; set; }

        public string OtherInfo { get; set; }
    }
}
