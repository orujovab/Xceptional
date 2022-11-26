using IComp.Core.Entities;
using IComp.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Data
{
    public class StoreDbContext : IdentityDbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {

        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Processor> Processors { get; set; }
        public DbSet<ProcessorSerie> ProcessorSeries { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<ProdType> ProdTypes { get; set; }
        public DbSet<MotherBoard> MotherBoards { get; set; }
        public DbSet<MemoryCapacity> MemoryCapacities { get; set; }
        public DbSet<ProdMemory> ProdMemories { get; set; }
        public DbSet<VideoCardSerie> VideoCardSeries { get; set; }
        public DbSet<VideoCard> VideoCards { get; set; }
        public DbSet<HardDisc> HardDiscs { get; set; }
        public DbSet<HDDCapacity> HDDCapacities { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Software> Softwares { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<ProductComment> ProductComments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<SSD> SSDs { get; set; }
        public DbSet<SSDCapacity> SSDCapacities { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<CheckedProducts> CheckedProducts { get; set; }
        public DbSet<FeedBack> FeedBa{ get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new ProcessorConfiguration());
            modelBuilder.ApplyConfiguration(new ProcessorSerieConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new MotherBoardConfiguration());
            modelBuilder.ApplyConfiguration(new MemoryConfiguration());
            modelBuilder.ApplyConfiguration(new VideoCardConfiguration());
            modelBuilder.ApplyConfiguration(new HardDiscConfiguration());
            modelBuilder.ApplyConfiguration(new HDDCapacityConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
