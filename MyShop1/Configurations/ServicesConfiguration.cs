using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MyShop.AUTH.Interfaces;
using MyShop.AUTH.Services;
using MyShop.Core.EF;
using MyShop.Core.Repositories;
using MyShop.Data.Entities;
using MyShop.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop1.Configurations
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddServices(
            this IServiceCollection services)
        {
            services
                .AddTransient<IAuthService, AuthService>()
                .AddTransient<IJwtGenerator, JwtGenerator>()
                .AddTransient<IRoleRepository, RoleRepository>()
                .AddTransient<IUserRepository, UserRepository>()
                .AddTransient<ICategoryRepository, CategoryRepository>()
                .AddTransient<IProductRepository, ProductRepository>()
                .AddTransient<IChangeRoleRepository, ChangeRoleRepository>()
                .AddTransient<ICommentsRepository, CommentsRepository>();


            return services;
        }

        public static IServiceCollection AddCorsConfiguration(this IServiceCollection services) =>
           services.AddCors(options => {
               options.AddPolicy("AllowAll", builder =>
               builder.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader());
           });

        public static IServiceCollection ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole<Guid>>(o =>
            {
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireLowercase = false;
            })
                .AddEntityFrameworkStores<ShopDbContext>()
                .AddDefaultTokenProviders();
            
            return services;
        }
    }
}
