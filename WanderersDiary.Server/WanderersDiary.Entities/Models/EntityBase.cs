using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanderersDiary.Entities.Models
{
    public class EntityBase
    {
        public long Id { get; set; }

        public DateTime Created { get; set; }
    }
}
