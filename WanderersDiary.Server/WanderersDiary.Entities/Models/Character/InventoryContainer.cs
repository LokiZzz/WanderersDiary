using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanderersDiary.Entities.Models.Character
{
    public class InventoryContainer : EntityBase
    {
        public string Name { get; set; }

        public ICollection<InventoryItem> Items { get; set; }
    }
}
