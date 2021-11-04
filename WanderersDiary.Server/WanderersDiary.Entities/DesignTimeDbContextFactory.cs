using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WanderersDiary.Entities
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<WDDbContext>
    {
        public WDDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<WDDbContext> optionsBuilder = new DbContextOptionsBuilder<WDDbContext>();
            optionsBuilder.UseSqlServer("data source=localhost;initial catalog=WDDB;integrated security=True;MultipleActiveResultSets=True;",
                opt =>
                {
                    opt.MigrationsHistoryTable(HistoryRepository.DefaultTableName);
            });

            return new WDDbContext(optionsBuilder.Options);
        }
    }
}
