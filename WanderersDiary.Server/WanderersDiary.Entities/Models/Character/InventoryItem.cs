using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanderersDiary.Entities.Models
{
    public class InventoryItem : EntityBase
    {
        public string Name { get; set; }

        public int Weight { get; set; }
    }
}
