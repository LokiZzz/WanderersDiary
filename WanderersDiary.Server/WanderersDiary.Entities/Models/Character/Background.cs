using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanderersDiary.Entities.Models
{
    public class Background : EntityBase
    {
        public string Title { get; set; }

        public string FactionsAndTitles { get; set; }

        public string BackgroundFeatures { get; set; }

        public string Description { get; set; }
    }
}
