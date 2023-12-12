using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using webApi.models;
using WebShiffi.models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace webApi.Dal
{
    public class ChineseSaleContext : DbContext
    {
        public ChineseSaleContext(DbContextOptions<ChineseSaleContext> options) : base(options)
        {

        }


        public DbSet<Users> Users { get; set; }
        public DbSet<Gift> Gifts { get; set; }
        public DbSet<Donors> Donors { get; set; }
    
        public DbSet<Winners> Winners { get; set; }
        public DbSet<Raffles> Raffles { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Donation> Donation { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(" Data Source =DESKTOP-E0FAPSB\\SQLEXPRESS;Initial Catalog = ChiniesSale1; Integrated Security = True");
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)

        //{
        //         base.OnModelCreating(modelBuilder);
        //         modelBuilder.Entity<Donation>()
        //        .HasOne(g => g.Gift)
        //        .WithMany(d => d.DonorToGift)
        //        .HasForeignKey(x => x)
        //        .HasForeignKey(key => key.Donors.DonorsId);

        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    base.OnModelCreating(modelBuilder);
        //}


    }
}