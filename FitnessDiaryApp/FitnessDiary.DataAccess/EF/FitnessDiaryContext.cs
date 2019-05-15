using FitnessDiary.DataAccess.Entities;
using FitnessDiary.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitnessDiary.DataAccess.EF
{
    public class FitnessDiaryContext : DbContext, IFitnessDiaryContext
    {
        private static readonly string ConnectionString = @"Server=.;Database=fitnessDiary;Integrated Security=True;MultipleActiveResultSets=True;";

        public FitnessDiaryContext() : base()
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Company>()
            //    .HasMany(l => l.ExhaustHoods)
            //    .WithOne(u => u.Company)
            //    .HasForeignKey(u => u.CompanyId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Company>()
            //    .HasMany(l => l.Sinks)
            //    .WithOne(u => u.Company)
            //    .HasForeignKey(u => u.CompanyId)
            //    .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
