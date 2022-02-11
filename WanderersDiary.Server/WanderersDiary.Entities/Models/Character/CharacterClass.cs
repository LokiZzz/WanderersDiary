using System;
using System.Collections.Generic;
using System.Text;
using WanderersDiary.Shared.Game;
using WanderersDiary.Entities.Character;
using WanderersDiary.Entities.Models;

namespace WanderersDiary.Entities
{
    public class CharacterClass : EntityBase
    {
        public int Level { get; set; }

        public EClass Class { get; set; }

        public int Archetype { get; set; }


        //ФИЧИ БУДУТ ПРОСТО СПИСКОМ ИНДЕКСОВ, ПО КОТОРЫМ БУДЕТ ВОССТАНАВЛИВАТЬСЯ БИЗНЕС-ЛОГИКА
        //public ICollection<Feature> Features { get; set; }
    }
}
