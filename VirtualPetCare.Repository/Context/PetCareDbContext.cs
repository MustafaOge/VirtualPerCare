using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection;
using VirtualPetCare.Repository.Seeds;
using VirtualPetCareAPI.Entities;
using System.Threading.Tasks;
using VirtualPetCare.Repository.Configurations;

namespace VirtualPetCare.Repository.Context
{
    public class PetCareDbContext : DbContext
    {
        public PetCareDbContext(DbContextOptions<PetCareDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetFood> PetFoods { get; set; }
        public DbSet<HealthStatus> HealthStatuses { get; set; }
        public DbSet<PetActivity> Activities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new UserLocalConfiguration());

            modelBuilder.ApplyConfiguration(new UserSeed());
        }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(connectionString: "User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=PetCareDb;");
        }

    }
}
