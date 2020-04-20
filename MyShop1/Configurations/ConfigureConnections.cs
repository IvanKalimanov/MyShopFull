using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyShop.Core.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop1.Configurations
{
    public static class ConfigureConnections
    {
        public static IServiceCollection AddConnectionProvider(
            this IServiceCollection services, IConfiguration conf)
        {
            var constr = conf.GetConnectionString("Shop");
            services
                .AddDbContext<ShopDbContext>(options =>
                    options.UseSqlServer(constr,
                    b => b.MigrationsAssembly("MyShop1")));
               


            return services;
        }
    }
}
