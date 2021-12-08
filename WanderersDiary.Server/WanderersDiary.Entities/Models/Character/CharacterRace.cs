using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanderersDiary.Shared.Game.Enums;

namespace WanderersDiary.Entities.Models
{
    public class CharacterRace : EntityBase
    {
        public ERace Race { get; set; }

        /// <summary>
        /// Subrace is another feature specified in race business logic.
        /// </summary>
        public ICollection<Feature> Features { get; set; }
    }
}
