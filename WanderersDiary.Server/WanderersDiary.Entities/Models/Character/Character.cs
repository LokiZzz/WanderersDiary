using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanderersDiary.Entities.Models.User;

namespace WanderersDiary.Entities.Models
{
    public class Character : EntityBase
    {
        public string Name { get; set; }

        public Wanderer Wanderer { get; set; }

        public class Config : EntityTypeConfiguration<Character> { }
    }
}
