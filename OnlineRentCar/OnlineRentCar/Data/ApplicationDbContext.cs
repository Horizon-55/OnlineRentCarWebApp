using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineRentCar.Models;

namespace OnlineRentCar.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Car> cars { get; set; }
        public DbSet<Crossover> crossoversCar { get; set; }
        public DbSet<ElectroCar> ElectroCars { get; set; }
        public DbSet<Minivan> minivanCar { get; set; }
        public DbSet<Sport> SportCar {get; set; }
        public DbSet<Rent> RentCars { get; set;}
        public DbSet<Returns> ReturnsCars {get; set; }
        public DbSet<AdminData> admindata {get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => new { u.Id}).HasName("IdUser");

            modelBuilder.Entity<Car>().HasOne(e => e.Rent).WithOne(b => b.Cars).HasForeignKey<Rent>(a => a.Car);
            modelBuilder.Entity<Rent>().HasOne(e => e.Users).WithMany(b => b.Rent).HasForeignKey(a => a.User);
            modelBuilder.Entity<Car>().HasOne(e => e.Returns).WithOne(c => c.Cars).HasForeignKey<Returns>(b => b.Car);
            modelBuilder.Entity<Returns>().HasOne(e => e.Users).WithMany(b => b.Returns).HasForeignKey(b => b.User);
        }

    }
}
