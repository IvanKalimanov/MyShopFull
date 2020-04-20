using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Core.EF
{
    public class ShopDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> opt) : base(opt)
        {
            Database.EnsureCreated();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<RefreshToken>()
               .HasKey(rt => new { rt.UserId, rt.Token });
            mb.Entity<IdentityRole<Guid>>().HasData(
                new IdentityRole<Guid>[]
                {
                    new IdentityRole<Guid>
                    {
                        Id = Guid.NewGuid(),
                        Name = "user",
                        NormalizedName = "USER"
                    },
                    new IdentityRole<Guid>
                    {
                        Id = Guid.NewGuid(),
                        Name = "admin",
                        NormalizedName = "ADMIN"
                    }
                });

            base.OnModelCreating(mb);
        }
    }

    
}
