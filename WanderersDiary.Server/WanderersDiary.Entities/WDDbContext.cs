using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using WanderersDiary.Entities.Models;
using WanderersDiary.Entities.Models.Auth;
using WanderersDiary.Entities.Models.User;

namespace WanderersDiary.Entities
{
    public class WDDbContext : IdentityDbContext<Wanderer>
    {
        public WDDbContext(DbContextOptions options) : base(options) { }

        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public DbSet<Character.Character> Characters { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(EntityTypeConfiguration<>).Assembly);
        }
    }
}
