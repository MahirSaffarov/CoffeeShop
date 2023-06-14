using CoffeeShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Metadata;

namespace CoffeeShop.DAL
{
    public class AppDbContext: IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
        public DbSet<Product> Products { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<ProductAroma> ProductAromas { get; set; }
        public DbSet<Aroma> Aromas { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Product>().HasQueryFilter(p => !p.IsDeleted);

        //    //modelBuilder.Entity<Customers>().HasData(
        //    //    new Customers
        //    //    {
        //    //        Id = 1,
        //    //        Name = "Nicat",
        //    //        Img = "img-png.png",
        //    //        IsDeleted = false,
        //    //        Message = "lorem"
        //    //    }
        //    //);
        //}
    }
}
