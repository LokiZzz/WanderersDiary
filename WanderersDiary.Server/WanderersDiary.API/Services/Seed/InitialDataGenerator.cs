using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanderersDiary.Entities;

namespace WanderersDiary.API.Seed
{
    public static class InitialDataGenerator
    {
        public static IHost InitiailizeDatabase(this IHost host)
        {
            using (IServiceScope scope = host.Services.CreateScope())
            {
                using (WDDbContext context = scope.ServiceProvider.GetRequiredService<WDDbContext>())
                {
                    InitiailizeClasses(context);
                }
            }

            return host;
        }

        private static void InitiailizeClasses(WDDbContext context)
        {
            
        }
    }
}
