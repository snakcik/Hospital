using Hospital.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Data.Context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options){ }
        public DbSet<AppRole> Roles { get; set; }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Departman>Departmens { get; set; }
        public DbSet<Inventory> Inventorys { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Personell> Personells { get; set; }
        public DbSet<Policlinic> Policlinics { get; set; }
        public DbSet<Title> Titles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }



    }
}
