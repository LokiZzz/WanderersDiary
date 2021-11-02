using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanderersDiary.Entities.Models.Character
{
    public class Character : EntityBase
    {
        public string Name { get; set; }

        public HashSet<> MyProperty { get; set; }

        public class Config : EntityTypeConfiguration<Character> { }
    }
}
